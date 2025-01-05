using Dtos.Hiring;

namespace Repository.Interface
{
    public interface IHiringHostelRepository
    {
        Task CreateHiringHostel(CreateHiringDto hiringDto, int accountId);
        Task DeleteHiringHostel();
        Task<IEnumerable<HiringDto>> GetAllHiringsHistory(int roomId);
        Task<HiringDto> GetHiringCurrent(int roomId);
        Task<HiringDto> GetHiringByID(int hiringId);
    }
}
