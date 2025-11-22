using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelManagement.State
{
    public class AuthState
    {
        public static User _currentUser;
        public static User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                _currentUser.PasswordHash = null; // Clear password hash for security
            }
        }
    }
}
