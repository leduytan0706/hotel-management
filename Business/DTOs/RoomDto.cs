using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.DTOs
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public RoomStatus Status { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public decimal DefaultPrice { get; set; }
        public int MaximumCapacity { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
