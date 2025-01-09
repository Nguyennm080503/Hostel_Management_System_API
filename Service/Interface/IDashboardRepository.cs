using Dtos.Dashboard;

namespace Service.Interface
{
    public interface IDashboardRepository
    {
        Task<DashboardDto> GetCustomerTotalStatistic(int accountId, DateTime? dateStart, DateTime? dateEnd);
    }
}
