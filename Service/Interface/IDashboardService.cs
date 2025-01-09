using Dtos.Dashboard;

namespace Service.Interface
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetCustomerTotalStatistic(int accountId, DateTime? dateStart, DateTime? dateEnd);
    }
}
