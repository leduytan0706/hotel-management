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

        public IEnumerable<BookingService> GetBookingServicesByService(int serviceId)
        {
            return _dbSet.Where(d => d.ServiceId == serviceId).ToList();
        }

        public int GetBookingServicesCountByService(int serviceId)
        {
            return _dbSet.Where(d => d.ServiceId == serviceId).Count();
        }

        public virtual void InsertMany(List<BookingService> bookingServices)
        {
            _dbSet.AddRange(bookingServices);
            _context.SaveChanges();
        }

        public IEnumerable<BookingService> GetByBookingId(int bookingId)
        {
            return _dbSet.Where(d => d.BookingId == bookingId).ToList();
        }
    }
}
