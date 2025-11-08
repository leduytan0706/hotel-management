using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class RoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePricePerNight { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
