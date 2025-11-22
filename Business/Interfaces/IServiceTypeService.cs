using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IServiceTypeService
    {
        bool CreateServiceType(ServiceType serviceType);
        bool UpdateServiceType(ServiceType serviceType);
        bool DeleteServiceType(int serviceTypeId);
        ServiceType GetServiceTypeById(int serviceTypeId);
        List<ServiceType> GetAllServiceTypes();
    }
}
