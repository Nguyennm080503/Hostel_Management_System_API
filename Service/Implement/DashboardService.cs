using Dtos.Dashboard;
using Service.Interface;

namespace Service.Implement
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;
        public DashboardService(IDashboardRepository dashboardRepository) 
        {
            _repository = dashboardRepository;
        }

        public async Task<IEnumerable<DashboardPaymentDto>> GetCustomerDashboardPayment(int accountId, DateTime? dateStart, DateTime? dateEnd)
        {
            return await _repository.GetCustomerDashboardPayment(accountId, dateStart, dateEnd);
        }

        public async Task<IEnumerable<DashboardPaymentMonthDto>> GetCustomerDashboardPaymentEachMonth(int accountId, DateTime? dateStart, DateTime? dateEnd)
        {
            return await _repository.GetCustomerDashboardPaymentEachMonth(accountId, dateStart, dateEnd);
        }

        public async Task<DashboardDto> GetCustomerTotalStatistic(int accountId, DateTime? dateStart, DateTime? dateEnd)
        {
            return await _repository.GetCustomerTotalStatistic(accountId, dateStart, dateEnd);
        }
    }
}
