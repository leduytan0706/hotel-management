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
    public class ServiceService: IServiceService
    {
        private readonly ServiceRepository _repo;
        private readonly ServiceTypeRepository _serviceTypeRepo;
        public ServiceService()
        {
            var context = new HotelDbContext();
            _repo = new ServiceRepository(context);
            _serviceTypeRepo = new ServiceTypeRepository(context);
        }
        public bool CreateService(Service service)
        {
            service.CreatedAt = DateTime.Now;
            service.UpdatedAt = DateTime.Now;
            service.IsAvailable = true;
            _repo.Insert(service);

            ServiceType serviceType = _serviceTypeRepo.GetById(service.ServiceTypeId);
            serviceType.ServiceCount += 1;
            _serviceTypeRepo.Update(serviceType);
            return true;
        }
        
        public bool UpdateService(Service service)
        {
            Service existingService = _repo.GetById(service.ServiceId);
            if (service.ServiceTypeId != existingService.ServiceTypeId)
            {
                ServiceType oldServiceType = _serviceTypeRepo.GetById(existingService.ServiceTypeId);
                oldServiceType.ServiceCount -= 1;
                _serviceTypeRepo.Update(oldServiceType);
                ServiceType newServiceType = _serviceTypeRepo.GetById(service.ServiceTypeId);
                newServiceType.ServiceCount += 1;
                _serviceTypeRepo.Update(newServiceType);
            }
            service.UpdatedAt = DateTime.Now;
            _repo.Update(service);
            throw new NotImplementedException();
        }

        public bool DeleteService(int serviceId)
        {
            BookingServiceService bookingServiceService = new BookingServiceService();
            int bookingServicesCount = bookingServiceService.GetBookingServicesCountByService(serviceId);
            if (bookingServicesCount > 0)
            {
                throw new Exception("Dịch vụ đang được sử dụng trong các đặt phòng, không thể xóa.");
            }
            _repo.Delete(serviceId);
            return true;
        }

        public bool DisableService(int serviceId)
        {
            Service service = _repo.GetById(serviceId);
            service.IsAvailable = false;
            _repo.Update(service);
            return true;
        }

        public Service GetServiceById(int serviceId)
        {
            return _repo.GetById(serviceId);
        }

        public List<Service> GetAllServices()
        {
            return _repo.GetAll().ToList();
        }

        public List<Service> GetServicesByServiceType(int serviceTypeId)
        {
            return _repo.GetServicesByType(serviceTypeId).ToList();
        }

        public List<Service> FilterServices(
                int serviceTypeId = 0,
                string searchTerm = ""
            )
        {
           if (serviceTypeId > 0)
            {
                return _repo.GetAll()
                    .Where(s => 
                        (
                            (s.ServiceName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0) 
                            || (s.Description.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                        && s.ServiceTypeId == serviceTypeId
                    )
                    .ToList();
            }
           else
            {
                return _repo.GetAll()
                    .Where(s =>
                            (s.ServiceName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                            || (s.Description.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    )
                    .ToList();
            }
        }
    }
}
