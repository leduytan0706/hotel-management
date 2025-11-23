using HotelManagement.Data;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repo;
        public CustomerService()
        {
            var context = new HotelDbContext();
            _repo = new CustomerRepository(context);

        }

        public Customer GetCustomerByPhone(string phone)
        {
            return _repo.GetByPhone(phone);
        }

        public bool CreateCustomer(Customer customer)
        {
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            _repo.Insert(customer);
            return true;
        }

        public bool UpdateCustomer(Customer customer) 
        {
            customer.UpdatedAt = DateTime.Now;
            _repo.Update(customer);
            return true;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _repo.GetById(customerId);
        }
    }
}
