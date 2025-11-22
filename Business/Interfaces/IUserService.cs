using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IUserService
    {
        bool CreateUser(User user);

        bool UpdateUser(User user);

        bool UpdateProfile(User user);

        bool DeleteUser(int userId);

        IEnumerable<User> GetAllUsers();

        IEnumerable<User> GetUserByRole(UserRole role);

        User GetUserById(int userId);
    }
}
