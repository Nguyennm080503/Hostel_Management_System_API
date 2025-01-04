using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Service;

namespace Service.Interface
{
    public interface IServiceHostelService
    {
        Task<IEnumerable<HostelServiceDto>> GetAllServiceOfCustomer(int hostelID);
        Task AddNewService(IEnumerable<NewHostelServiceDto> newHostels);
    }
}
