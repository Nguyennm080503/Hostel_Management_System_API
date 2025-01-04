using Dtos.Service;
using Models;
using Repository.Interface;
using Service.Exception;
using Service.Interface;

namespace Service.Implement
{
    public class ServiceRoomService : IServiceRoomService
    {
        private readonly IServiceRoomRepository _serviceRoomRepository;
        public ServiceRoomService(IServiceRoomRepository serviceRoomRepository)
        {
            _serviceRoomRepository = serviceRoomRepository;
        }

        public async Task AddNewService(NewServiceRoomDto serviceDto, int accountID)
        {
            var service = await _serviceRoomRepository.GetServiceName(serviceDto.ServiceHostelName, accountID);

            if (service != null)
            {
                throw new ServiceException("Dịch vụ này đã tồn tại !");
            }
            await _serviceRoomRepository.AddNewService(serviceDto, accountID);
            return;
        }

        public async Task DeleteService(int serviceID)
        {
            await _serviceRoomRepository.DeleteService(serviceID);
            return;
        }

        public async Task<IEnumerable<ServiceRoomDto>> GetAllServiceOfCustomer(int accountID)
        {
            return await _serviceRoomRepository.GetAllServiceOfCustomer(accountID);
        }

        public async Task UpdateService(UpdateServiceHiringDto updateService)
        {
            await _serviceRoomRepository.UpdateService(updateService);
            return;
        }
    }
}
