using Dao;
using Dtos.Dashboard;
using Service.Interface;

namespace Service.Implement
{
    public class DashboardRepository : IDashboardRepository
    {
        public async Task<DashboardDto> GetCustomerTotalStatistic(int accountId, DateTime? dateStart, DateTime? dateEnd)
        {
            var countHostel = await HostelDao.Instance.GetAllHostelsOfCustomer(accountId);
            var countBill = await BillDao.Instance.GetBillsByAccount(accountId);
            var countService = await ServiceHiringDao.Instance.GetAllServiceOfCustomer(accountId);

            var effectiveDateStart = dateStart ?? DateTime.MinValue;
            var effectiveDateEnd = dateEnd.HasValue && dateEnd.Value != DateTime.MinValue ? dateEnd.Value : DateTime.MaxValue;

            var filteredBills = countBill
                .Where(x => x.DateCreate >= effectiveDateStart && x.DateCreate <= effectiveDateEnd)
                .ToList();

            var totalReceive = filteredBills
                .Where(x => x.BillPaymentType == 1)
                .Sum(x => x.BillPaymentAmount);

            var totalSpending = filteredBills
                .Where(x => x.BillPaymentType == 2)
                .Sum(x => x.BillPaymentAmount);

            return new DashboardDto
            {
                CountHostelCustomer = countHostel.Count(),
                CountService = countService.Count(),
                CountTotalReceive = (int)totalReceive,
                CountTotalSpending = (int)totalSpending,
            };
        }
    }
}
