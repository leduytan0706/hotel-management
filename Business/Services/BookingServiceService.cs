using HotelManagement.Data;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Services
{
    public class BookingServiceService
    {
        private readonly BookingServiceRepository _repo;

        public BookingServiceService()
        {
            var context = new HotelDbContext();
            _repo = new BookingServiceRepository(context);
        }
        public List<Models.BookingService> GetBookingServicesByService(int serviceId)
        {
            return _repo.GetBookingServicesByService(serviceId).ToList();
        }

        public int GetBookingServicesCountByService(int serviceId)
        {
            return _repo.GetBookingServicesCountByService(serviceId);
        }

        public bool CreateBookingServices(int bookingId, List<Models.BookingService> bookingServices)
        {
            List<Models.BookingService> servicesToAdd = bookingServices.Select(s => new Models.BookingService
            {
                BookingId = bookingId,
                ServiceId = s.ServiceId,
                UnitPrice = s.UnitPrice,
                Quantity = s.Quantity,
                TotalPrice = s.UnitPrice * s.Quantity,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }).ToList();
            _repo.InsertMany(servicesToAdd);

            return true;
        }
    }
}
