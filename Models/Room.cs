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
    public enum RoomStatus
    {
        [Description("Đang đặt")]
        Booked,
        [Description("Trống")]
        Free,
        [Description("Đang sửa chữa")]
        UnderRepair,
        [Description("Không sử dụng")]
        Inactive,
        [Description("Đang sử dụng")]
        Occupied,
        [Description("Đang dọn dẹp")]
        Cleaning
    }
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public RoomStatus Status { get; set; } = RoomStatus.Free;

        public bool IsDeleted { get; set; } = false;
        public string Description { get; set; }
        public decimal DefaultPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int MaximumCapacity { get; set; }

        public virtual RoomType Type { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        //public virtual ICollection<RoomPrice> CustomPrices { get; set; }
    }
}
