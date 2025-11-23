using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IBookingService
    {
        bool CreateBooking(Booking booking, List<Models.BookingService> bookingServices);
        bool CreateBookingAndCustomer(Booking booking, Customer customer, List<Models.BookingService> bookingServices);

        bool UpdateBooking(Booking booking);

        bool DeleteBooking(int bookingId);

        Booking GetBookingById(int bookingId);

        List<Booking> GetAllBookings();

        List<Booking> GetBookingsByCustomer(int customerId);

        List<Booking> FilterBookings(
                string roomNumber,
                string customerPhone,
                DateTime? startDate,
                DateTime? endDate,
                BookingStatus? status
            );
    }
}
