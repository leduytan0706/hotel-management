using HotelManagement.Business.Interfaces;
using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Services
{
    public class UserService: IUserService
    {
        private readonly UserRepository _repo;
        public UserService()
        {
            var context = new HotelDbContext();
            _repo = new UserRepository(context);
        }
        public bool CreateUser(User user)
        {
            string hashedPassword = PasswordHelper.EncryptPassword(user.PasswordHash);
            user.PasswordHash = hashedPassword;
            user.IsActive = true;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            _repo.Insert(user);
            return true;
        }

        public bool UpdateUser(User user)
        {
            User existingUser = _repo.GetById(user.UserId);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            bool isPasswordSame = PasswordHelper.VerifyPassword(user.PasswordHash, existingUser.PasswordHash);
            if (!isPasswordSame)
            {
                string hashedPassword = PasswordHelper.EncryptPassword(user.PasswordHash);
                existingUser.PasswordHash = hashedPassword;
            }
            _repo.Update(user);
            return true;
        }

        public bool UpdateProfile(User user)
        {
            return true;
        }

        public bool DeleteUser(int userId)
        {
            _repo.Delete(userId);
            return true;
        }

        public IEnumerable<User> GetUserByRole(UserRole role)
        {
            return _repo.GetUsersByRole(role);
        }

        public User GetUserById(int userId)
        {
            return _repo.GetById(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repo.GetAll();
        }
    }
}
