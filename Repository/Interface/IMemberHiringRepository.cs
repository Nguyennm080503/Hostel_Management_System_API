using Dtos.Hiring;

namespace Repository.Interface
{
    public interface IMemberHiringRepository
    {
        Task<IEnumerable<HiringMemberDto>> GetAllMembers(int hiringId);
        Task CreateNewMember(NewHiringMemberDto member);

        Task DeleteMember(int memberId);
        Task<HiringMemberDto> GetMemberByID(int memberHiringID);
    }
}
