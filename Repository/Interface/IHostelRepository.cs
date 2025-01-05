using Dtos.Hostel;

namespace Repository.Interface
{
    public interface IHostelRepository
    {
        Task<IEnumerable<HostelDto>> GetAllHostelOfCustomer(int accountId);
        Task AddNewHostel(NewHostelDto hostel, int accountId);
        Task<HostelDto> GetHostelByName(string hostelName, int accountId);
        Task<HostelDto> GetHostelByID(int hostelID);
        Task UpdateHostel(UpdateHostelDto hostelDto, int accountId);
        Task UpdateHostelHiring(int hostelId);
        Task DeleteHostel(int hostelId);
    }
}
