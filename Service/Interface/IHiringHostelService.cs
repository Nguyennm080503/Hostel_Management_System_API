using Dtos.Hiring;

namespace Service.Interface
{
    public interface IHiringHostelService
    {
        Task CreateHiringHostel(CreateHiringDto hiringDto, int accountId);
        Task<IEnumerable<HiringDto>> GetAllHiringsHistory(int roomId);
        Task<HiringInformationDto> GetHiringCurrent(int roomId);
    }
}
