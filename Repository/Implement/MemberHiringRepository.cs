using AutoMapper;
using AutoMapper.Execution;
using Dao;
using Dtos.Hiring;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class MemberHiringRepository : IMemberHiringRepository
    {
        private readonly IMapper _mapper;
        public MemberHiringRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task CreateNewMember(NewHiringMemberDto member)
        {
            var newMember = _mapper.Map<MemberHiringRoom>(member);
            await MemberHiringDao.Instance.CreateAsync(newMember);

            return;
        }

        public async Task DeleteMember(int memberId)
        {
            var member = await MemberHiringDao.Instance.GetMemberInRoom(memberId);
            await MemberHiringDao.Instance.RemoveAsync(member);

            return;
        }

        public async Task<IEnumerable<HiringMemberDto>> GetAllMembers(int hiringId)
        {
            var members = await MemberHiringDao.Instance.GetMembersInRoom(hiringId);
            return _mapper.Map<IEnumerable<HiringMemberDto>>(members);
        }

        public async Task<HiringMemberDto> GetMemberByID(int memberHiringID)
        {
            var member = await MemberHiringDao.Instance.GetMemberInRoom(memberHiringID);
            return _mapper.Map<HiringMemberDto>(member);
        }
    }
}
