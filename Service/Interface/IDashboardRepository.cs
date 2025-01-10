using Dtos.Dashboard;

namespace Service.Interface
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<DashboardPaymentDto>> GetCustomerDashboardPayment(int accountId, DateTime? dateStart, DateTime? dateEnd);
        Task<IEnumerable<DashboardPaymentMonthDto>> GetCustomerDashboardPaymentEachMonth(int accountId, DateTime? dateStart, DateTime? dateEnd);
        Task<DashboardDto> GetCustomerTotalStatistic(int accountId, DateTime? dateStart, DateTime? dateEnd);
    }
}
