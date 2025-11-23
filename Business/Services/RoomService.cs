using HotelManagement.Business.DTOs;
using HotelManagement.Business.Interfaces;
using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Services
{
    public class RoomService: IRoomService
    {
        private readonly RoomRepository _repo;
        private readonly RoomTypeRepository _roomTypeRepo;
        private readonly RoomPriceRepository _roomPriceRepo;
        private readonly BookingRepository _bookingRepo;

        public RoomService()
        {
            var context = new HotelDbContext();
            _repo = new RoomRepository(context);
            _roomTypeRepo = new RoomTypeRepository(context);
            _roomPriceRepo = new RoomPriceRepository(context);
            _bookingRepo = new BookingRepository(context);
        }
        public bool CreateRoomAndCustomPrice(Room room, List<RoomPrice> roomPrices)
        {
            if (_repo.CheckExistsByRoomNumber(room.RoomNumber))
                throw new Exception("Phòng này đã tồn tại!");

            var roomType = _roomTypeRepo.GetById(room.RoomTypeId);
            if (roomType == null)
                throw new Exception("Loại phòng không hợp lệ!");

            room.Status = RoomStatus.Free;
            room.CreatedAt = DateTime.Now;
            room.UpdatedAt = DateTime.Now;

            var roomId = _repo.InsertAndReturnId(room);
            if (roomId == 0)
                throw new Exception("Tạo phòng không thành công.");

            roomPrices.ForEach(p => p.RoomId = roomId);
            try
            {
                _roomPriceRepo.InsertMany(roomPrices);
            } catch (Exception ex)
            {
                throw new Exception("Thêm giá phòng không thành công.");
            }
            
            return true;
        }

        public bool CreateRoom(Room room)
        {
            if (_repo.CheckExistsByRoomNumber(room.RoomNumber))
                throw new Exception("Phòng này đã tồn tại!");

            var roomType = _roomTypeRepo.GetById(room.RoomTypeId);
            if (roomType == null)
                throw new Exception("Loại phòng không hợp lệ!");

            room.Status = RoomStatus.Free;
            room.CreatedAt = DateTime.Now;
            room.UpdatedAt = DateTime.Now;

            _repo.Insert(room);
            return true;
        }
        public bool UpdateRoomAndCustomPrice(Room room, List<RoomPrice> roomPrices)
        {
            if (_repo.CheckExistsByRoomNumber(room.RoomNumber))
                throw new Exception("Phòng này đã tồn tại!");

            var roomType = _roomTypeRepo.GetById(room.RoomTypeId);
            if (roomType == null)
                throw new Exception("Loại phòng không hợp lệ!");

            try
            {
                room.UpdatedAt = DateTime.Now;
                _repo.Update(room);

                List<RoomPrice> pricesToAdd;
                List<RoomPrice> pricesToRemove;
                List<RoomPrice> pricesToUpdate;

                var existingRoomPrices = _roomPriceRepo.GetPricesForRoom(room.RoomId);
                if (existingRoomPrices == null || existingRoomPrices.Any())
                {
                    _roomPriceRepo.InsertMany(roomPrices);
                }
                else
                {
                    pricesToAdd = roomPrices.Where(price => price.RoomPriceId == 0).ToList();
                    pricesToRemove = existingRoomPrices.Where(p => !roomPrices.Contains(p)).ToList();
                    pricesToUpdate = existingRoomPrices.Where(p => roomPrices.Contains(p)).ToList();

                    pricesToUpdate.ForEach(price =>
                    {
                        if (_roomPriceRepo.CheckExistsStartAndEndDateForUpdate(price))
                        {
                            throw new Exception($"Khoảng thời gian cho giá {price.PricePerNight} trùng lặp.");
                        }
                    });

                    pricesToAdd.ForEach(price =>
                    {
                        if (_roomPriceRepo.CheckExistsStartAndEndDateForInsert(price))
                        {
                            throw new Exception($"Khoảng thời gian cho giá {price.PricePerNight} trùng lặp.");
                        }
                        price.RoomId = room.RoomId;
                    });

                    _roomPriceRepo.UpdateMany(pricesToUpdate);
                    _roomPriceRepo.InsertMany(pricesToAdd);
                    _roomPriceRepo.DeleteMany(pricesToRemove);
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Cập nhật phòng không thành công.");
            }  

        }

        public bool UpdateRoom(Room room)
        {
            if (_repo.CheckExistsByRoomNumber(room.RoomNumber))
                throw new Exception("Phòng này đã tồn tại!");

            var roomType = _roomTypeRepo.GetById(room.RoomTypeId);
            if (roomType == null)
                throw new Exception("Loại phòng không hợp lệ!");

            room.UpdatedAt = DateTime.Now;
            _repo.Update(room);
            return true;
        }
        public bool DeleteRoom(int roomId)
        {
            var existingRoomPrices = _roomPriceRepo.GetPricesForRoom(roomId);
            if (existingRoomPrices == null || existingRoomPrices.Any()) {
                _roomPriceRepo.DeleteMany(existingRoomPrices.ToList());
            }
            int bookingCount = _bookingRepo.GetBookingCountByRoom(roomId);
            if (bookingCount > 0)
            {
                throw new Exception("Không thể xóa phòng vì đã có hóa đơn liên quan. Hãy chuyển trạng thái phòng sang không sử dụng.");
            }

            return _repo.DisableRoom(roomId);
        }
        public IEnumerable<RoomDto> GetAllRooms()
        {
            return _repo.GetAllRooms();
        }

        public RoomDto GetRoomById(int roomId)
        {
            var room = _repo.GetById(roomId);
            return new RoomDto
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                RoomTypeId = room.RoomTypeId,
                RoomTypeName = room.Type.Name,
                Status = room.Status,
                StatusName = room.Status.GetDescription(),
                Description = room.Description,
                DefaultPrice = room.DefaultPrice,
                MaximumCapacity = room.Type.MaximumCapacity,
                UpdatedAt = room.UpdatedAt
            };
        }

        public IEnumerable<RoomDto> SearchRooms(
            string searchTerm = "",
            int roomTypeId = 0,
            decimal minPrice = 0,
            decimal maxPrice = decimal.MaxValue,
            int minCapacity = 0,
            int maxCapacity = int.MaxValue
            )
        {
            IEnumerable<RoomDto> filteredRooms = _repo.GetAllRooms();
            if (roomTypeId > 0)
            {
                filteredRooms = filteredRooms.Where(r => r.RoomTypeId == roomTypeId);
            }

            // 3. Lọc theo Giá (Price)
            // Giả định DefaultPrice là thuộc tính giá của Room
            if (minPrice > 0 || maxPrice < decimal.MaxValue)
            {
                filteredRooms = filteredRooms.Where(r =>
                    r.DefaultPrice >= minPrice && r.DefaultPrice <= maxPrice);
            }

            // 4. Lọc theo Sức chứa tối đa (MaximumCapacity)
            if (minCapacity > 0 || maxCapacity < int.MaxValue)
            {
                filteredRooms = filteredRooms.Where(r =>
                    r.MaximumCapacity >= minCapacity && r.MaximumCapacity <= maxCapacity);
            }

            // 5. Lọc theo Từ khóa tìm kiếm (Search Term)
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string lowerSearchTerm = searchTerm.ToLower();
                filteredRooms = filteredRooms.Where(r =>
                    r.RoomNumber.ToLower().Contains(lowerSearchTerm) ||
                    r.Description.ToLower().Contains(lowerSearchTerm) // Hoặc các trường khác như RoomTypeName
                );
            }

            return filteredRooms;
        }
    }
}
