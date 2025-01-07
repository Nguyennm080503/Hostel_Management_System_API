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
            var hiring = _mapper.Map<HiringRoomHostel>(hiringDto);
            hiring.AccountOwnerID = accountId;
            hiring.DateCreate = DateTime.Now;
            hiring.Status = HiringStatusEnum.Hiring.ToString();
            hiring.DateHiring = (int)(hiring.HiringEnd.Value - hiring.HiringStart.Value).TotalDays;

            await HiringHostelDao.Instance.CreateAsync(hiring);

            return;
        }

        public async Task CreateServiceLogIndex(NewServiceLogIndexDto logIndexDto)
        {
            var indexLog = _mapper.Map<ServiceLogIndex>(logIndexDto);
            indexLog.DateCreate = DateTime.Now;

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
    }
}
