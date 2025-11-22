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
    public class ServiceTypeService: IServiceTypeService
    {
        private readonly ServiceTypeRepository _repo;

        public ServiceTypeService()
        {
            var context = new HotelDbContext();
            _repo = new ServiceTypeRepository(context);
        }
        public bool CreateServiceType(ServiceType serviceType)
        {
            serviceType.CreatedAt = DateTime.Now;
            serviceType.UpdatedAt = DateTime.Now;
            _repo.Insert(serviceType);
            return true;
        }

        public bool UpdateServiceType(ServiceType serviceType)
        {
            serviceType.UpdatedAt = DateTime.Now;
            _repo.Update(serviceType);
            return true;
        }

        public bool DeleteServiceType(int serviceTypeId)
        {
            ServiceType serviceType = _repo.GetById(serviceTypeId);
            if (serviceType == null)
            {
                throw new Exception("Service type not found");
            }
            if (serviceType.ServiceCount > 0)
            {
                throw new Exception("Cannot delete service type with associated services");
            }
            _repo.Delete(serviceTypeId);
            return true;
        }

        public ServiceType GetServiceTypeById(int serviceTypeId)
        {
            return _repo.GetById(serviceTypeId);
        }
        
        public List<ServiceType> GetAllServiceTypes()
        {
            return _repo.GetAll().ToList();
        }

   
    }
}
