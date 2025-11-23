using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IServiceService
    {
        bool CreateService(Service service);

        bool UpdateService(Service service);

        bool DeleteService(int serviceId);

        Service GetServiceById(int serviceId);

        List<Service> GetAllServices();

        List<Service> GetServicesByServiceType(int serviceTypeId);

        List<Service> FilterServices(
                int serviceTypeId,
                string searchTerm
            );
    }
}
