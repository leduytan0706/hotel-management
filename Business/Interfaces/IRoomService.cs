using HotelManagement.Business.DTOs;
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
        bool CreateRoomAndCustomPrice(Room room, List<RoomPrice> roomPrices);
        bool CreateRoom(Room room);

        bool UpdateRoomAndCustomPrice(Room room, List<RoomPrice> roomPrices);
        bool UpdateRoom(Room room);
        bool DeleteRoom(int roomId);
        IEnumerable<RoomDto> GetAllRooms();
    }
}
