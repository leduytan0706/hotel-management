using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IRoomPriceService
    {
        bool CreateRoomPrices(List<RoomPrice> roomPrices);
        //bool CreateRoomPrice(RoomPrice roomPrice);
        bool UpdateRoomTypes(List<RoomPrice> roomPrices);
        //bool UpdateRoomType(int roomPriceId, RoomPrice roomPrice);
        bool DeleteRoomPrices(List<RoomPrice> roomPrices);
        IEnumerable<RoomPrice> GetPricesForRoom(int roomId);

        decimal GetRoomPriceByDate(int roomId, DateTime checkInDate);

    }
}
