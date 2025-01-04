using Dtos.Service;

namespace Service.Interface
{
    public interface IServiceRoomService
    {
        Task<IEnumerable<ServiceRoomDto>> GetAllServiceOfCustomer(int accountID);
        Task AddNewService(NewServiceRoomDto serviceDto, int accountID);
        Task DeleteService(int serviceID);
        Task UpdateService(UpdateServiceHiringDto updateService);
    }
}
