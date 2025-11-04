using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    internal class RoomTypeRepository: BaseRepository<RoomType>
    {
        public RoomTypeRepository(HotelDbContext context) : base(context) { }
    }
}
