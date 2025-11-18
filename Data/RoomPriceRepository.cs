using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class RoomPriceRepository: BaseRepository<RoomPrice>
    {
        public RoomPriceRepository(HotelDbContext context) : base(context) { }

        public decimal GetRoomPriceByDate(int roomId, DateTime checkInDate)
        {
            return _dbSet
                .Where(p => p.RoomId == roomId 
                    && checkInDate >= p.StartDate 
                    && checkInDate <= p.EndDate
                )
                .Select(p => p.PricePerNight)
                .FirstOrDefault();
     
        }

        public virtual void InsertMany(List<RoomPrice> priceList)
        {
            _dbSet.AddRange(priceList);
            _context.SaveChanges();
        }

        public virtual void UpdateMany(List<RoomPrice> priceList) 
        {
            _dbSet.AddOrUpdate(priceList.ToArray());
            _context.SaveChanges();
        }

        public virtual void DeleteMany(List<RoomPrice> priceList)
        {
            _dbSet.RemoveRange(priceList);
            _context.SaveChanges();
        }

        public IEnumerable<RoomPrice> GetPricesForRoom(int roomId)
        {
            return _dbSet
                .Where(p => p.RoomId == roomId)
                .OrderBy(p => p.StartDate)
                .ToList();
        }

        public bool CheckExistsStartAndEndDateForUpdate(RoomPrice price)
        {
            return _dbSet
                .Where(p =>
                    ((price.StartDate >= p.StartDate && price.StartDate <= p.EndDate) ||
                    (price.EndDate >= p.StartDate && price.EndDate <= p.EndDate)) &&
                    price.RoomPriceId != p.RoomPriceId
                )
                .Count() > 0;
               
        }

        public bool CheckExistsStartAndEndDateForInsert(RoomPrice price)
        {
            return _dbSet
                .Where(p =>
                    (price.StartDate >= p.StartDate && price.StartDate <= p.EndDate) ||
                    (price.EndDate >= p.StartDate && price.EndDate <= p.EndDate)
                )
                .Count() > 0;

        }
    }
}
