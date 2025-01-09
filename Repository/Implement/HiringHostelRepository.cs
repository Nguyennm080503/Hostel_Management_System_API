using AutoMapper;
using Common.Enum;
using Dao;
using Dtos.Hiring;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class HiringHostelRepository : IHiringHostelRepository
    {
        private readonly IMapper _mapper;
        public HiringHostelRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task CreateHiringHostel(CreateHiringDto hiringDto, int accountId)
        {
            var hiring = new HiringRoomHostel();
            if(hiringDto.HiringType == 1 || hiringDto.HiringType == 3)
            {
                hiring.RoomID = hiringDto.RoomID;
            }
            hiring.AccountOwnerID = accountId;
            hiring.DateCreate = DateTime.Now;
            hiring.Status = HiringStatusEnum.Hiring.ToString();
            hiring.DateHiring = (int)(hiringDto.HiringEnd.Value - hiringDto.HiringStart.Value).TotalDays;
            hiring.AccountHiringCitizen = hiringDto.AccountHiringCitizen;
            hiring.AccountHiringPhone = hiringDto.AccountHiringPhone;
            hiring.AccountHiringAddress = hiringDto.AccountHiringAddress;
            hiring.AccountHiringName = hiringDto.AccountHiringName;
            hiring.DepositAmount = hiringDto.DepositAmount;
            hiring.HiringEnd = hiringDto.HiringEnd;
            hiring.HiringStart = hiringDto.HiringStart;
            hiring.HiringType = hiringDto.HiringType;
            hiring.HostelID = hiringDto.HostelID;

            await HiringHostelDao.Instance.CreateAsync(hiring);

            return;
        }

        public async Task CreateServiceLogIndex(NewServiceLogIndexDto logIndexDto)
        {
            var indexLog = new ServiceLogIndex();
            indexLog.DateCreate = DateTime.Now;
            indexLog.ServiceLog = (int)logIndexDto.ServiceLog;
            indexLog.ServiceRoomID = logIndexDto.ServiceRoomID;

            await ServiceLogIndexDao.Instance.CreateAsync(indexLog);

            return;
        }

        public Task DeleteHiringHostel()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HiringDto>> GetAllHiringsHistory(int roomId)
        {
            var hirings = await HiringHostelDao.Instance.GetAllHiringsHistory(roomId);
            return _mapper.Map<IEnumerable<HiringDto>>(hirings);
        }

        public async Task<HiringDto> GetHiringByID(int hiringId)
        {
            var hiring = await HiringHostelDao.Instance.GetHiringByID(hiringId);
            return _mapper.Map<HiringDto>(hiring);
        }

        public async Task<HiringDto> GetHiringCurrent(int roomId)
        {
            var hiring = await HiringHostelDao.Instance.GetHiringHostelCurrent(roomId);
            return _mapper.Map<HiringDto>(hiring);
        }

        public async Task<HiringDto> GetHiringCurrentByHostel(int hostelId)
        {
            var hiring = await HiringHostelDao.Instance.GetHiringHostelCurrentByHostel(hostelId);
            return _mapper.Map<HiringDto>(hiring);
        }
    }
}
