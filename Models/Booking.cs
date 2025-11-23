using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public enum BookingStatus
    {
        [Description("Đang xử lý")]
        Pending,
        [Description("Đã xác nhận")]
        Confirmed,
        [Description("Đã Check In")]
        CheckedIn,
        [Description("Đã Check Out")]
        CheckedOut,
        [Description("Đã hủy")]
        Cancelled
    }
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        public int? CustomerId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string IdNumber { get; set; }
        public int RoomId { get; set; }
        public decimal BookedPrice { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public BookingStatus Status { get; set; }
        public int UserId { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<BookingService> BookingServices { get; set; }
        public virtual User User { get; set; }
    }
}
