using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Service;

namespace Repository.Interface
{
    public interface IServiceHostelRepository
    {
        Task<IEnumerable<HostelServiceDto>> GetAllServiceOfCustomer(int hostelID);
        Task AddNewService(NewHostelServiceDto serviceDto);
        Task DeleteService(int serviceID);
        Task<HostelServiceDto> GetServiceByID(int serviceID);
        Task<HostelServiceDto> GetServiceRoomExisted(int serviceID, int hostelId);
    }
}
