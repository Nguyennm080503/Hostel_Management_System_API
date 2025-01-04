using Dtos.Hostel;

namespace Service.Interface
{
    public interface IHostelService
    {
        Task<IEnumerable<HostelDto>> GetAllHostelOfCustomer(int accountId);
        Task AddNewHostel(NewHostelDto hostel, int accountId);
        Task UpdateHostel(UpdateHostelDto hostelDto, int accountId);
        Task DeleteHostel(int hostelId);
    }
}
