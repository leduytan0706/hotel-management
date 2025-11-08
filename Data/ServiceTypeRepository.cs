using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class ServiceTypeRepository: BaseRepository<ServiceType>
    {
        public ServiceTypeRepository(HotelDbContext context) : base(context) { }
    }
}
