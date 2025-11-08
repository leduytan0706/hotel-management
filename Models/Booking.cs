using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public enum BookingStatus
    {
        Pending,
        CheckedIn,
        CheckedOut,
        Cancelled
    }
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public BookingStatus Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<BookingService> BookingServices { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
