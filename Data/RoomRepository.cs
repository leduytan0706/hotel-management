using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    internal class RoomRepository: BaseRepository<Room>
    {
        public RoomRepository(HotelDbContext context) : base(context) { }

        public IEnumerable<Room> GetAvailableRooms()
        {
            return _dbSet.Where(r => r.Status.Equals(RoomStatus.Free)).ToList();
        }

        public IEnumerable<Room> GetBusyRooms()
        {
            return _dbSet.Where(r => r.Status.Equals(RoomStatus.Booked)).ToList();
        }
    }
}
