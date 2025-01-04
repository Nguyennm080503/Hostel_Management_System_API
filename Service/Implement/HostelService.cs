using AutoMapper;
using Dtos.Hostel;
using Repository.Interface;
using Service.Exception;
using Service.Interface;

namespace Service.Implement
{
    public class HostelService : IHostelService
    {
        private readonly IHostelRepository _hostelRepository;
        private readonly IMapper _mapper;

        public HostelService(
           IHostelRepository hostelRepository,
           IMapper mapper)
        {
            _hostelRepository = hostelRepository;
            _mapper = mapper;
        }
        public async Task AddNewHostel(NewHostelDto hostelDto, int accountId)
        {
            var hostel = await _hostelRepository.GetHostelByName(hostelDto.HostelName, accountId);

            if (hostel != null)
            {
                throw new ServiceException("Nhà này đã tồn tại !");
            }
            await _hostelRepository.AddNewHostel(hostelDto, accountId);
            return;
        }

        public async Task DeleteHostel(int hostelId)
        {
            await _hostelRepository.DeleteHostel(hostelId);
            return;
        }

        public async Task<IEnumerable<HostelDto>> GetAllHostelOfCustomer(int accountId)
        {
            return await _hostelRepository.GetAllHostelOfCustomer(accountId);
        }

        public async Task UpdateHostel(UpdateHostelDto hostelDto, int accountId)
        {
            await _hostelRepository.UpdateHostel(hostelDto, accountId);
            return;
        }
    }
}
