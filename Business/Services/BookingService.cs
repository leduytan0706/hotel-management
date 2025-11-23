using HotelManagement.Business.Interfaces;
using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingRepository _repo;
        private readonly CustomerRepository _customerRepo;
        private readonly RoomRepository _roomRepo;
        private readonly RoomScheduleRepository _roomScheduleRepo;
        public BookingService()
        {
            var context = new HotelDbContext();
            _customerRepo = new CustomerRepository(context);
            _repo = new BookingRepository(context);
            _roomRepo = new RoomRepository(context);
            _roomScheduleRepo = new RoomScheduleRepository(context);
        }

        public bool CreateBooking(Booking booking, List<Models.BookingService> bookingServices)
        {
            booking.BookingDate = DateTime.Now;
            booking.UpdatedAt = DateTime.Now;
            booking.Status = BookingStatus.Pending;
            booking.UserId = AuthState.CurrentUser.UserId;
            _repo.Insert(booking);

            // Fix for CS0266: Explicitly cast nullable DateTime to non-nullable DateTime
            var newRoomSchedule = new RoomSchedule
            {
                RoomId = booking.RoomId,
                StartDate = booking.CheckInDate.HasValue ? booking.CheckInDate.Value : DateTime.MinValue,
                EndDate = booking.CheckOutDate.HasValue ? booking.CheckOutDate.Value : DateTime.MinValue,
                Status = RoomStatus.Booked,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                BookingId = booking.BookingId,
                UserId = AuthState.CurrentUser.UserId
            };
            _roomScheduleRepo.Insert(newRoomSchedule);

            if (bookingServices.Count > 0)
            {
                BookingServiceService bookingServiceService = new BookingServiceService();
                bookingServiceService.CreateBookingServices(booking.BookingId, bookingServices);
            }

            return true;
        }

        public bool CreateBookingAndCustomer(Booking booking, Customer customer, List<Models.BookingService> bookingServices)
        {
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            var customerId = _customerRepo.InsertAndReturnId(customer);
            booking.CustomerId = customerId;

            this.CreateBooking(booking, bookingServices);
            return true;
        }

        public bool ConfirmBooking(Booking booking)
        {
            booking.Status = BookingStatus.Confirmed;
            booking.UpdatedAt = DateTime.Now;
            _repo.Update(booking);
            return true;
        }

        public bool CheckInBooking(Booking booking)
        {
            booking.Status = BookingStatus.CheckedIn;
            booking.UpdatedAt = DateTime.Now;
            _repo.Update(booking);

            RoomSchedule roomSchedule = _roomScheduleRepo.GetByBooking(booking.BookingId);
            roomSchedule.Status = RoomStatus.Occupied;
            roomSchedule.UpdatedAt = DateTime.Now;
            _roomScheduleRepo.Update(roomSchedule);

            Room room = _roomRepo.GetById(booking.RoomId);
            room.Status = RoomStatus.Occupied;
            room.UpdatedAt = DateTime.Now;
            _roomRepo.Update(room);

            return true;
        }

        public bool CheckOutBooking(Booking booking)
        {
            booking.Status = BookingStatus.CheckedOut;
            booking.UpdatedAt = DateTime.Now;
            _repo.Update(booking);

            RoomSchedule roomSchedule = _roomScheduleRepo.GetByBooking(booking.BookingId);
            roomSchedule.Status = RoomStatus.Free;
            roomSchedule.UpdatedAt = DateTime.Now;
            _roomScheduleRepo.Update(roomSchedule);

            Room room = _roomRepo.GetById(booking.RoomId);
            room.Status = RoomStatus.Free;
            room.UpdatedAt = DateTime.Now;
            _roomRepo.Update(room);

            return true;
        }

        public bool CancelBooking(Booking booking)
        {
            booking.Status = BookingStatus.Cancelled;
            booking.UpdatedAt = DateTime.Now;
            _repo.Update(booking);

            RoomSchedule roomSchedule = _roomScheduleRepo.GetByBooking(booking.BookingId);
            roomSchedule.Status = RoomStatus.Free;
            roomSchedule.UpdatedAt = DateTime.Now;
            _roomScheduleRepo.Update(roomSchedule);

            Room room = _roomRepo.GetById(booking.RoomId);
            room.Status = RoomStatus.Free;
            room.UpdatedAt = DateTime.Now;
            _roomRepo.Update(room);
            return true;
        }

        public bool UpdateBooking(Booking booking, List<Models.BookingService> bookingServices)
        {
            // 1. Set updated fields
            booking.UpdatedAt = DateTime.Now;

            // 2. Update Booking
            _repo.Update(booking);

            // 3. Update RoomSchedule (vì ngày CheckIn/CheckOut có thể thay đổi)
            var existingSchedule = _roomScheduleRepo
                .GetAll()
                .Where(s => s.BookingId == booking.BookingId)
                .FirstOrDefault();

            if (existingSchedule != null)
            {
                existingSchedule.RoomId = booking.RoomId;
                existingSchedule.StartDate = booking.CheckInDate.HasValue ? booking.CheckInDate.Value : DateTime.MinValue;
                existingSchedule.EndDate = booking.CheckOutDate.HasValue ? booking.CheckOutDate.Value : DateTime.MinValue;
                existingSchedule.Status = RoomStatus.Booked; // giữ trạng thái
                existingSchedule.UpdatedAt = DateTime.Now;

                _roomScheduleRepo.Update(existingSchedule);
            }

            // 4. Update BookingServices
            BookingServiceService bookingServiceService = new BookingServiceService();

            // Xóa dịch vụ cũ trước
            bookingServiceService.DeleteByBookingId(booking.BookingId);

            // Sau đó thêm lại dịch vụ mới
            if (bookingServices != null && bookingServices.Count > 0)
            {
                bookingServiceService.CreateBookingServices(booking.BookingId, bookingServices);
            }

            return true;
        }

        public bool UpdateBookingAndCustomer(Booking booking)
        {
            booking.UpdatedAt = DateTime.Now;
            return true;
        }

        public bool DeleteBooking(int BookingId)
        {
            return true;
        }

        public Booking GetBookingById(int bookingId)
        {
            return _repo.GetById(bookingId);
        }

        public List<Booking> GetAllBookings()
        {
            return _repo.GetAll().OrderByDescending(b => b.UpdatedAt).ToList();
        }

        public List<Booking> GetBookingsByCustomer(int customerId)
        {
            return _repo.GetBookingsByCustomer(customerId).OrderByDescending(b => b.UpdatedAt).ToList();
        }

        public List<Booking> FilterBookings(
                string roomNumber,
                string customerPhone,
                DateTime? startDate,
                DateTime? endDate,
                BookingStatus? status
            )
        {
            Room room = _roomRepo.GetByRoomNumber(roomNumber);
            if (room == null)
                throw new Exception("Số phòng không tồn tại.");
            if (!startDate.HasValue)
            {
                startDate = DateTime.MinValue;
            }
            if (!endDate.HasValue)
            {
                endDate = DateTime.Today;
            }
            return _repo.GetAll()
                .Where(b =>
                    (b.RoomId == room.RoomId)
                    || (b.Phone.Contains(customerPhone))
                    || (b.CheckInDate >= startDate && b.CheckInDate <= endDate)
                    || (b.CheckOutDate >= startDate && b.CheckOutDate <= endDate)
                    || (!status.HasValue || b.Status == status.Value)
                )
                .OrderByDescending(b => b.UpdatedAt)
                .ToList();
        }

        public string GetNewBookingNumber()
        {
            DateTime today = DateTime.Today;
            string formattedDate = today.ToString("yyyyMMdd");
            string prefix = "BKG" + formattedDate + "-";

            var dailyBookings = _repo.GetAll()
                                      .Where(b => b.BookingNumber.Contains(formattedDate))
                                      .ToList(); 

            int newNumber = 1;

            if (dailyBookings.Any())
            {
                
                var latestNumber = dailyBookings

                    .Where(b => b.BookingNumber.StartsWith(prefix))
                    .Select(b =>
                    {

                        string numberPart = b.BookingNumber.Split('-').LastOrDefault();

                        if (int.TryParse(numberPart, out int number))
                        {
                            return number;
                        }
                        return 0; 
                    })
                    .Max();


                newNumber = latestNumber + 1;
            }

            return prefix + newNumber.ToString("D3");
        }
    }
}
