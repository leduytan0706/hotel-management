using HotelManagement.Business.Interfaces;
using HotelManagement.Data;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Services
{
    public class RoomTypeService: IRoomTypeService
    {
        private readonly RoomTypeRepository _roomTypeRepo;

        public RoomTypeService()
        {
            var context = new HotelDbContext();
            _roomTypeRepo = new RoomTypeRepository(context);
        }

        public bool CreateRoomType(RoomType roomType)
        {
            _roomTypeRepo.Insert(roomType);
            return true;
        }

        public bool UpdateRoomType(RoomType roomType)
        {
            var selectRoomType = _roomTypeRepo.GetById(roomType.RoomTypeId);
            if (selectRoomType == null)
            {
                throw new Exception("Không tìm thấy loại phòng.");
            }
            selectRoomType.Name = roomType.Name;
            selectRoomType.Description = roomType.Description;
            selectRoomType.BasePricePerNight = roomType.BasePricePerNight;
            selectRoomType.MaximumCapacity = roomType.MaximumCapacity;
            _roomTypeRepo.Update(selectRoomType);
            return true;
        }

        public bool DeleteRoomType(int roomTypeId)
        {
            _roomTypeRepo.Delete(roomTypeId);
            return true;
        }

        public IEnumerable<RoomType> GetAllRoomTypes()
        {
            return _roomTypeRepo.GetAll();
        }
    }
}
