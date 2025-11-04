using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    internal class UserRepository: BaseRepository<User>
    {
        public UserRepository(HotelDbContext context) : base(context) { }

        public IEnumerable<User> GetUsersByRole(UserRole userRole)
        {
            return _dbSet.Where(b => b.Role.Equals(userRole)).ToList();
        }
    }
}
