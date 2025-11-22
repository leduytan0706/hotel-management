using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class RoomScheduleRepository: BaseRepository<RoomSchedule>
    {
        public RoomScheduleRepository(HotelDbContext context) : base(context) { }

        public bool IsAvailable(int roomId, DateTime start, DateTime end)
        {
            return !_dbSet.Any(log =>
                log.RoomId == roomId &&
                log.StartDate < end &&
                start < log.EndDate &&
                log.Status != RoomStatus.Cleaning
            );
        }
    }
}
