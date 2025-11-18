using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IRoomService
    {
        bool CreateRoom(Room room, List<RoomPrice> roomPrices);
        bool UpdateRoom(int roomId, Room room, List<RoomPrice> roomPrices);
        bool DeleteRoom(int roomId);
        IEnumerable<Room> GetAllRooms();
    }
}
