using Dtos.Service;

namespace Repository.Interface
{
    public interface IServiceRoomRepository
    {
        Task<IEnumerable<ServiceRoomDto>> GetAllServiceOfCustomer(int accountID);
        Task AddNewService(NewServiceRoomDto serviceDto, int accountID);
        Task<ServiceRoomDto> GetServiceName(string serviceName, int accountID);
        Task DeleteService(int serviceID);
        Task<ServiceRoomDto> GetServiceByID(int serviceID);
        Task UpdateService(UpdateServiceHiringDto updateService);
    }
}
