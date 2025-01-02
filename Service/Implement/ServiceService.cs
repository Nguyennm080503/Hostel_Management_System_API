using AutoMapper;
using Dtos.Service;
using Microsoft.Extensions.Configuration;
using Repository.Interface;
using Service.Exception;
using Service.Interface;

namespace Service.Implement
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ServiceService(
           IConfiguration configuration,
           IServiceRepository serviceRepository,
           IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task AddNewService(NewServiceDto serviceDto)
        {
            var service = await _serviceRepository.GetServiceInFlatfrom(serviceDto.ServiceName);

            if (service != null)
            {
                throw new ServiceException("Dịch vụ này đã tồn tại !");
            }
            await _serviceRepository.AddNewService(serviceDto);
            return;
        }

        public async Task DeleteService(int serviceID)
        {
            var service = await _serviceRepository.GetServiceByID(serviceID);

            if (service == null)
            {
                throw new ServiceException("Dịch vụ này không tồn tại !");
            }
            await _serviceRepository.DeleteService(serviceID);
            return;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServicesInFlatfrom()
        {
            return await _serviceRepository.GetAllServicesInFlatfrom();
        }
    }
}
