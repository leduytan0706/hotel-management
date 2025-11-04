using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelManagement.Utils
{
    internal class Validator
    {
        public static string ValidateBookingForm(Booking booking)
        {
            if (booking.CustomerId == 0)
            {
                return "Khách hàng không hợp lệ.";
            }
            if (booking.RoomId == 0)
            {
                return "Phòng không hợp lệ.";
            }
            if (booking.BookingDate == null)
            {
                return "Ngày đặt phòng không hợp lệ.";
            }
            if (booking.CheckInDate == null)
            {
                return "Ngày lấy phòng (Check-in) không hợp lệ.";
            }
            if (booking.CheckOutDate == null)
            {
                return "Ngày trả phòng (Check-out) không hợp lệ.";
            }
            return "";
        }

        public static string ValidateBookingServiceForm(BookingService bookingService)
        {
            if (bookingService.BookingId == 0)
            {
                return "Phiếu đặt phòng không hợp lệ.";
            }
            if (bookingService.ServiceId == 0)
            {
                return "Dịch vụ không hợp lệ.";
            }
            if (bookingService.Quantity <= 0)
            {
                return "Số lượng không hợp lệ.";
            }
            if (bookingService.UnitPrice == null)
            {
                return "Ngày lấy phòng (Check-in) không hợp lệ.";
            }
            return "";
        }

        public static string ValidateServiceForm(Service service)
        {
            if (service.ServiceTypeId == 0)
            {
                return "Loại dịch vụ không hợp lệ.";
            }
            if (service.ServiceName.Length == 0)
            {
                return "Tên dịch vụ không hợp lệ.";
            }
            if (service.UnitPrice <= 0)
            {
                return "Đơn giá không hợp lệ.";
            }
            return "";
        }

        public static string ValidateCustomerForm(Customer customer)
        {
            if (customer.FullName.Length == 0)
            {
                return "Tên khách hàng không hợp lệ.";
            }
            if (customer.Phone.Length == 0)
            {
                return "Số điện thoại không hợp lệ.";
            }
            if (customer.IdNumber.Length == 0)
            {
                return "Số căn cước không hợp lệ.";
            }
            return "";
        }

        public static string ValidateUserForm(User user)
        {
            if (user.FullName.Length == 0)
            {
                return "Tên người dùng không hợp lệ.";
            }
            if (user.Phone.Length == 0)
            {
                return "Số điện thoại không hợp lệ.";
            }
            if (user.IdNumber.Length == 0)
            {
                return "Số căn cước không hợp lệ.";
            }
            if (user.Address.Length == 0)
            {
                return "Địa chỉ không hợp lệ.";
            }
            return "";
        }
    }
}
