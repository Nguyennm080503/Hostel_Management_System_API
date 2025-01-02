using Dtos.Service;

namespace Repository.Interface
{
    public interface IServiceRepository
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesInFlatfrom();
        Task AddNewService(NewServiceDto serviceDto);
        Task<ServiceDto> GetServiceInFlatfrom(string serviceName);
        Task DeleteService(int serviceID);
        Task<ServiceDto> GetServiceByID(int serviceID);
    }
}
