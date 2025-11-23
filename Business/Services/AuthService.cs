using HotelManagement.Business.Interfaces;
using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.State;
using HotelManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Services
{
    public class AuthService: IAuthService
    {
        private readonly UserRepository _repo;
        public AuthService()
        {
            var context = new HotelDbContext();
            _repo = new UserRepository(context);
        }
        public bool Login(string username, string password)
        {
            User user = _repo.GetUserByUsername(username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            bool isPasswordValid = PasswordHelper.VerifyPassword(password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new Exception("Email or password is incorrect.");
            }
            AuthState.CurrentUser = user;
            return true;
        }
    }
}
