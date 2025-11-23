using HotelManagement.Business.DTOs;
using HotelManagement.Models;
using HotelManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<RoomDto> GetAllRooms()
        {
            return _dbSet
                .Where(r => !r.IsDeleted)
                .Include(r => r.Type)
                .ToList()
                .Select(r => new RoomDto
                {
                    RoomId = r.RoomId,
                    RoomNumber = r.RoomNumber,
                    RoomTypeId = r.RoomTypeId,
                    RoomTypeName = r.Type.Name,
                    Status = r.Status,
                    StatusName = r.Status.GetDescription(),
                    Description = r.Description,
                    DefaultPrice = r.DefaultPrice,
                    MaximumCapacity = r.Type.MaximumCapacity,
                    UpdatedAt = r.UpdatedAt
                });
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

        public Room GetByRoomNumber(string roomNumber)
        {
            return _dbSet
                .Where(p => p.RoomNumber == roomNumber)
                .FirstOrDefault();
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
