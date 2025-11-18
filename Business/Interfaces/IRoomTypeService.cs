using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IRoomTypeService
    {
        bool CreateRoomType(RoomType roomType);
        bool UpdateRoomType(RoomType roomType);
        bool DeleteRoomType(int roomTypeId);
        IEnumerable<RoomType> GetAllRoomTypes();
    }
}
