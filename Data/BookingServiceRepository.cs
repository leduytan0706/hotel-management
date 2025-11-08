using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class BookingServiceRepository: BaseRepository<BookingService>
    {
        public BookingServiceRepository(HotelDbContext context) : base(context) { }

        public IEnumerable<BookingService> GetServicesByBooking(int bookingId)
        {
            return _dbSet.Where(d => d.BookingId == bookingId).ToList();
        }
    }
}
