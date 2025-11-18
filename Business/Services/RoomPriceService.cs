using HotelManagement.Data;
using HotelManagement.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public class RoomPriceService: IRoomPriceService
    {
        private readonly RoomPriceRepository _roomPriceRepo;
        private readonly RoomRepository _roomRepo;
        public RoomPriceService()
        {
            var context = new HotelDbContext();
            _roomPriceRepo = new RoomPriceRepository(context);
            _roomRepo = new RoomRepository(context);
        }
        public bool CreateRoomPrices(List<RoomPrice> roomPrices)
        {
            _roomPriceRepo.InsertMany(roomPrices);
            return true;
        }
        //bool CreateRoomPrice(RoomPrice roomPrice);
        public bool UpdateRoomTypes(List<RoomPrice> roomPrices)
        {
            _roomPriceRepo.UpdateMany(roomPrices);
            return true;
        }
        //bool UpdateRoomType(int roomPriceId, RoomPrice roomPrice);
        public bool DeleteRoomPrices(List<RoomPrice> roomPrices)
        {
            _roomPriceRepo.DeleteMany(roomPrices);
            return true;
        }
        public IEnumerable<RoomPrice> GetPricesForRoom(int roomId)
        {
            return _roomPriceRepo.GetPricesForRoom(roomId);
        }

        public decimal GetRoomPriceByDate(int roomId, DateTime checkInDate)
        {
            var price = _roomPriceRepo.GetRoomPriceByDate(roomId, checkInDate);
            if (price > 0) return price;
            return _roomRepo.GetRoomDefaultPrice(roomId);
        }
    }
}
