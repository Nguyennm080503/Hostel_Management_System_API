using AutoMapper;
using Dao;
using Dtos.Service;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class ServiceHostelRepository : IServiceHostelRepository
    {
        private readonly IMapper _mapper;
        public ServiceHostelRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task AddNewService(NewHostelServiceDto serviceDto)
        {

            var service = _mapper.Map<ServiceHostel>(serviceDto);

            await ServiceHostelDao.Instance.CreateAsync(service);
            return;
        }

        public Task DeleteService(int serviceID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HostelServiceDto>> GetAllServiceOfCustomer(int hostelID)
        {
            var services = await ServiceHostelDao.Instance.GetAllServiceOfCustomer(hostelID);

            return _mapper.Map<IEnumerable<HostelServiceDto>>(services);
        }

        public async Task<HostelServiceDto> GetServiceByID(int serviceID)
        {
            var service = await ServiceHostelDao.Instance.GetServiceID(serviceID);

            return _mapper.Map<HostelServiceDto>(service);
        }

        public async Task<HostelServiceDto> GetServiceRoomExisted(int serviceID, int hostelId)
        {
            var service = await ServiceHostelDao.Instance.GetServiceRoomExisted(serviceID, hostelId);

            return _mapper.Map<HostelServiceDto>(service);
        }
    }
}
