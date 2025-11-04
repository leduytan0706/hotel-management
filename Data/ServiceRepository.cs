using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    internal class ServiceRepository: BaseRepository<Service>
    {
        public ServiceRepository(HotelDbContext context) : base(context) { }

        public IEnumerable<Service> GetServicesByType(int serviceTypeId)
        {
            return _dbSet.Where(r => r.ServiceTypeId==serviceTypeId).ToList();
        }
    }
}
