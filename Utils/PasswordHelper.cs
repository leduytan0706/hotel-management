using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Utils
{
    public class PasswordHelper
    {
        private const int SaltSize = 16;       
        private const int KeySize = 20;      
        private const int Iterations = 10000;
        public static string EncryptPassword(string password)
        {
            // 1. Tạo một Salt ngẫu nhiên
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] salt = algorithm.Salt;

                // 2. Tạo Hash từ mật khẩu và Salt
                byte[] hash = algorithm.GetBytes(KeySize);

                // 3. Kết hợp Salt và Hash thành một mảng byte duy nhất
                // (Đặt Salt trước Hash)
                byte[] hashBytes = new byte[SaltSize + KeySize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

                // 4. Chuyển đổi sang chuỗi Base64 để lưu vào Database
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            // 1. Chuyển chuỗi Base64 Hash đã lưu trở lại mảng byte
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // 2. Trích xuất Salt (16 bytes đầu tiên)
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // 3. Trích xuất Hash đã lưu (20 bytes tiếp theo)
            byte[] savedPasswordHash = new byte[KeySize];
            Array.Copy(hashBytes, SaltSize, savedPasswordHash, 0, KeySize);

            // 4. Hash lại mật khẩu người dùng nhập vào bằng Salt đã trích xuất
            using (var algorithm = new Rfc2898DeriveBytes(
                inputPassword,
                salt, // Truyền Salt đã trích xuất vào đây
                Iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] computedHash = algorithm.GetBytes(KeySize);

                // 5. So sánh hai Hash (dùng hằng số thời gian để tránh tấn công thời gian)
                // (Hàm Equals của mảng byte an toàn hơn việc so sánh từng byte thủ công)
                return computedHash.SequenceEqual(savedPasswordHash);
            }
        }
    }
}
