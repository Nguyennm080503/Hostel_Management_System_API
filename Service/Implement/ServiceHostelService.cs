using Dtos.Service;
using Repository.Interface;
using Service.Exception;
using Service.Interface;

namespace Service.Implement
{
    public class ServiceHostelService : IServiceHostelService
    {
        private readonly IServiceHostelRepository _repository;
        public ServiceHostelService(IServiceHostelRepository repository)
        {
            _repository = repository;
        }
        public async Task AddNewService(IEnumerable<NewHostelServiceDto> newHostels)
        {
            var errors = new List<string>();

            foreach (var hostel in newHostels)
            {
                try
                {
                    var service = await _repository.GetServiceRoomExisted(hostel.ServiceHostelRoomID, hostel.HostelID);

                    if (service != null)
                    {
                        errors.Add($"Dịch vụ với ID {hostel.ServiceHostelRoomID} đã tồn tại.");
                        continue;
                    }
                    await _repository.AddNewService(hostel);
                }
                catch (IOException ex)
                {
                    errors.Add($"Lỗi khi thêm dịch vụ với ID {hostel.ServiceHostelRoomID}: {ex.Message}");
                }
            }

            if (errors.Any())
            {
                throw new ServiceException("Một số dịch vụ không thể thêm được");
            }

        }

        public async Task<IEnumerable<HostelServiceDto>> GetAllServiceOfCustomer(int hostelID)
        {
            return await _repository.GetAllServiceOfCustomer(hostelID);
        }
    }
}
