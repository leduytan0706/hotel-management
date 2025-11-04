using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    internal class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(HotelDbContext context) : base(context) { }

        public Customer FindByPhone(string phone)
        {
            return _dbSet.FirstOrDefault(c => c.Phone == phone);
        }

        public Customer FindByIdNumber(string idNumber)
        {
            return _dbSet.FirstOrDefault(c => c.IdNumber == idNumber);
        }


    }
}
