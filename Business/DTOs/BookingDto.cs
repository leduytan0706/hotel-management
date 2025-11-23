using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.DTOs
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public decimal BookedPrice { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string StatusName { get; set; }
        public string UserFullName { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string IdNumber { get; set; }
    }
}
