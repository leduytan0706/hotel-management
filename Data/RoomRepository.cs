using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class RoomRepository: BaseRepository<Room>
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

        public IEnumerable<Room> GetAllRooms()
        {
            return _dbSet.Where(r => !r.IsDeleted).ToList();
        }

        public decimal GetRoomDefaultPrice(int roomId)
        {
            return _dbSet
                .Where(p => p.RoomId == roomId)
                .Select(p => p.DefaultPrice)
                .FirstOrDefault();
        }

        public bool CheckExistsByRoomNumber(string roomNumber)
        {
            return _dbSet
                .Where(p => p.RoomNumber == roomNumber)
                .Count() > 0;
        }

        public int InsertAndReturnId(Room room)
        {
            return base.InsertAndReturnId(room, "RoomId");
        }

        public bool DisableRoom(int roomId)
        {
            var room = _dbSet.Find(roomId);
            if (room == null) return false;

            room.Status = RoomStatus.Inactive;
            _context.SaveChanges();
            return true;
        }

        public override void Delete(int roomId)
        {
            var room = _dbSet.Find(roomId);
            if (room != null)
            {
                room.IsDeleted = true;
                _context.SaveChanges();
            }
        }
    }
}
