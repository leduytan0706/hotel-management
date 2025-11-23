using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public enum InvoiceStatus
    {
        Finished,
        Unfinished
    }
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public int BookingId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal ServiceCharge { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public decimal DiscountAmount { get; set; } = 0;
        public decimal PaidAmount { get; set; } = 0;

        public int UserId { get; set; }
        public InvoiceStatus PaymentStatus { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual User User { get; set; }
    }
}
