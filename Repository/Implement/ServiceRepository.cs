using AutoMapper;
using Dao;
using Dtos.Service;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IMapper _mapper;

        public ServiceRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task AddNewService(NewServiceDto serviceDto)
        {
            var service = _mapper.Map<Service>(serviceDto);
            service.ServiceName = serviceDto.ServiceName;
            await ServiceDao.Instance.CreateAsync(service);

            return;
        }

        public async Task DeleteService(int serviceID)
        {
            var service = await ServiceDao.Instance.GetServiceID(serviceID);
            await ServiceDao.Instance.RemoveAsync(service);

            return;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServicesInFlatfrom()
        {
            var services = await ServiceDao.Instance.GetAllAsync();

            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceDto> GetServiceInFlatfrom(string serviceName)
        {
            var service = await ServiceDao.Instance.GetServiceName(serviceName);

            return _mapper.Map<ServiceDto>(service);
        }

        public async Task<ServiceDto> GetServiceByID(int serviceID)
        {
            var service = await ServiceDao.Instance.GetServiceID(serviceID);

            return _mapper.Map<ServiceDto>(service);
        }
    }
}
