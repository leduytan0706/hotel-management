using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class BookingRepository : BaseRepository<Booking>
    {
        public BookingRepository(HotelDbContext context) : base(context) { }

        public IEnumerable<Booking> GetBookingsByDateRange(DateTime start, DateTime end)
        {
            return _dbSet.Where(b => b.CheckInDate >= start && b.CheckOutDate <= end).ToList();
        }

        public IEnumerable<Booking> GetBookingsByCustomer(int customerId)
        {
            return _dbSet.Where(b => b.CustomerId==customerId).ToList();
        }
    }
}
