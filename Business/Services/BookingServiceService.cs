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
    }
}
