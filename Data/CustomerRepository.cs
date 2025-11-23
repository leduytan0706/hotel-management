using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(HotelDbContext context) : base(context) { }

        public Customer GetByPhone(string phone)
        {
            return _dbSet.FirstOrDefault(c => c.Phone == phone);
        }

        public Customer GetByIdNumber(string idNumber)
        {
            return _dbSet.FirstOrDefault(c => c.IdNumber == idNumber);
        }

        public int InsertAndReturnId(Customer customer)
        {
            return base.InsertAndReturnId(customer, "CustomerId");
        }

    }
}
