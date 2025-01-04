using AutoMapper;
using Common.Enum;
using Dao;
using Dtos.Service;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class ServiceRoomRepository : IServiceRoomRepository
    {
        private readonly IMapper _mapper;

        public ServiceRoomRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task AddNewService(NewServiceRoomDto serviceDto, int accountID)
        {
            var service = _mapper.Map<ServiceHostelRoom>(serviceDto);
            service.ServiceHostelName = serviceDto.ServiceHostelName;
            service.AccountID = accountID;
            service.ServiceHostelPrice = serviceDto.ServiceHostelPrice;
            service.MeasurementID = serviceDto.MeasurementID;
            service.Status = "Active";
            service.DateCreate = DateTime.Now;
            await ServiceHiringDao.Instance.CreateAsync(service);

            return;
        }

        public async Task DeleteService(int serviceID)
        {
            var service = await ServiceHiringDao.Instance.GetServiceID(serviceID);
            service.Status = ServiceHiringStatusEnum.Deleted.ToString();
            await ServiceHiringDao.Instance.UpdateAsync(service);
            return;
        }

        public async Task<IEnumerable<ServiceRoomDto>> GetAllServiceOfCustomer(int accountID)
        {
            var services = await ServiceHiringDao.Instance.GetAllServiceOfCustomer(accountID);

            return _mapper.Map<IEnumerable<ServiceRoomDto>>(services);
        }

        public async Task<ServiceRoomDto> GetServiceByID(int serviceID)
        {
            var service = await ServiceHiringDao.Instance.GetServiceID(serviceID);

            return _mapper.Map<ServiceRoomDto>(service);
        }

        public async Task<ServiceRoomDto> GetServiceName(string serviceName, int accountID)
        {
            var service = await ServiceHiringDao.Instance.GetServiceName(serviceName, accountID);

            return _mapper.Map<ServiceRoomDto>(service);
        }

        public async Task UpdateService(UpdateServiceHiringDto updateService)
        {
            var service = await ServiceHiringDao.Instance.GetServiceID(updateService.ServiceHostelID);
            service.ServiceHostelPrice = updateService.ServiceHostelPrice;
            await ServiceHiringDao.Instance.UpdateAsync(service);
            return;
        }
    }
}
