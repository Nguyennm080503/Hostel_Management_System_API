using AutoMapper;
using Dao;
using Dtos.Dashboard;
using Dtos.Hostel;
using Service.Interface;

namespace Service.Implement
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IMapper mapper;
        public DashboardRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DashboardPaymentDto>> GetCustomerDashboardPayment(int accountId, DateTime? dateStart, DateTime? dateEnd)
        {
            var bills = await BillDao.Instance.GetBillsByAccount(accountId);

            var effectiveDateStart = dateStart ?? DateTime.MinValue;
            var effectiveDateEnd = dateEnd.HasValue && dateEnd.Value != DateTime.MinValue ? dateEnd.Value : DateTime.MaxValue;

            var filteredBillsSpending = bills
                .Where(b => b.DateCreate >= effectiveDateStart && b.DateCreate <= effectiveDateEnd && b.BillPaymentType == 2);

            var filteredBillsReceive = bills
                .Where(b => b.DateCreate >= effectiveDateStart && b.DateCreate <= effectiveDateEnd && b.BillPaymentType == 1);

            var groupedData = bills
                .Where(b => b.DateCreate >= effectiveDateStart && b.DateCreate <= effectiveDateEnd) 
                .GroupBy(b => b.HostelID)
                .Select(group => new DashboardPaymentDto
                {
                    HostelID = group.Key ?? 0,
                    Hostel = mapper.Map<HostelDto>(group.FirstOrDefault().Hostel),
                    CountTotalSpending = filteredBillsSpending
                        .Where(b => b.HostelID == group.Key)
                        .Sum(b => (int)b.BillPaymentAmount),
                    CountTotalReceive = filteredBillsReceive
                        .Where(b => b.HostelID == group.Key)
                        .Sum(b => (int)b.BillPaymentAmount)
                });

            return groupedData;
        }

        public async Task<IEnumerable<DashboardPaymentMonthDto>> GetCustomerDashboardPaymentEachMonth(int accountId, DateTime? dateStart, DateTime? dateEnd)
        {
            var bills = await BillDao.Instance.GetBillsByAccount(accountId);

            var effectiveDateStart = dateStart ?? DateTime.MinValue;
            var effectiveDateEnd = dateEnd.HasValue && dateEnd.Value != DateTime.MinValue ? dateEnd.Value : DateTime.MaxValue;

            var filteredBillsSpending = bills
                .Where(b => b.DateCreate >= effectiveDateStart && b.DateCreate <= effectiveDateEnd && b.BillPaymentType == 2);

            var filteredBillsReceive = bills
                .Where(b => b.DateCreate >= effectiveDateStart && b.DateCreate <= effectiveDateEnd && b.BillPaymentType == 1);

            var groupedData = bills
                .Where(b => b.DateCreate >= effectiveDateStart && b.DateCreate <= effectiveDateEnd)
                .GroupBy(b => new { b.DateCreate.Year, b.DateCreate.Month })
                .Select(group => new DashboardPaymentMonthDto
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    CountTotalSpending = group
                        .Where(b => b.BillPaymentType == 2)
                        .Sum(b => (int)b.BillPaymentAmount),
                    CountTotalReceive = group
                        .Where(b => b.BillPaymentType == 1) 
                        .Sum(b => (int)b.BillPaymentAmount)
                })
                .OrderBy(dto => dto.Year)
                .ThenBy(dto => dto.Month);

            return groupedData;
        }

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
