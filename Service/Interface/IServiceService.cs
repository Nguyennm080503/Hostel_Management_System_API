using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Service;

namespace Service.Interface
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesInFlatfrom();
        Task AddNewService(NewServiceDto serviceDto);
        Task DeleteService(int serviceID);
    }
}
