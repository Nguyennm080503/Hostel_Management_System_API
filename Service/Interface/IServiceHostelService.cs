using Dtos.Service;

namespace Service.Interface
{
    public interface IServiceHostelService
    {
        Task<IEnumerable<HostelServiceDto>> GetAllServiceOfCustomer(int hostelID);
        Task AddNewService(IEnumerable<NewHostelServiceDto> newHostels);
    }
}
