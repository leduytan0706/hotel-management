using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<BookingService> BookingServices { get; set; }
    }
}
