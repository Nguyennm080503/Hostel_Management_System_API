using AutoMapper;
using Dao;
using Dtos.Hostel;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class HostelRepository : IHostelRepository
    {
        private readonly IMapper _mapper;
        public HostelRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task AddNewHostel(NewHostelDto hostelDto, int accountId)
        {
            var hostel = _mapper.Map<Hostel>(hostelDto);
            hostel.HostelName = hostelDto.HostelName;
            hostel.HostelAddress = hostelDto.HostelAddress;
            hostel.HostelRooms = hostelDto.HostelRooms;
            hostel.HostelType = hostelDto.HostelType;
            hostel.AccountID = accountId;
            hostel.Status = "Active";
            await HostelDao.Instance.CreateAsync(hostel);

            return;
        }

        public async Task<IEnumerable<HostelDto>> GetAllHostelOfCustomer(int accountId)
        {
            var hostels = await HostelDao.Instance.GetAllHostelsOfCustomer(accountId);
            return _mapper.Map<IEnumerable<HostelDto>>(hostels);
        }

        public async Task<HostelDto> GetHostelByID(int hostelID)
        {
            var hostel = await HostelDao.Instance.GetHostelID(hostelID);
            return _mapper.Map<HostelDto>(hostel);
        }

        public async Task<HostelDto> GetHostelByName(string hostelName, int accountId)
        {
            var hostel = await HostelDao.Instance.GetHostelName(hostelName, accountId);
            return _mapper.Map<HostelDto>(hostel);
        }
    }
}
