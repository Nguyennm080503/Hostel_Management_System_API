using AutoMapper;
using Dao;
using Dtos.Bill;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class BillPaymentRepository : IBillPaymentRepository
    {
        private readonly IMapper mapper;
        public BillPaymentRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task CreateNewBillPayment(NewBillDto newBill, int accountID)
        {
            var bill = mapper.Map<BillPayment>(newBill);
            bill.AccountCreateID = accountID;
            bill.DateCreate = DateTime.Now;
            bill.Status = "Paid";
            await BillDao.Instance.CreateAsync(bill);

            return;
        }

        public async Task CreateNewBillPaymentSpending(NewBillPayDto billDto, int accountId)
        {
            var bill = mapper.Map<BillPayment>(billDto);
            bill.AccountCreateID = accountId;
            bill.DateCreate = DateTime.Now;
            bill.Status = "Paid";
            await BillDao.Instance.CreateAsync(bill);

            return;

        }

        public async Task<BillDto> GetBillPaymentById(int billId)
        {
            var bill = await BillDao.Instance.GetBillByID(billId);
            if(bill == null)
            {
                return null;
            }
            return mapper.Map<BillDto>(bill);
        }

        public async Task<BillDto> GetBillPaymentCurrent(int hiringId)
        {
            var bill = await BillDao.Instance.GetBillCurrent(hiringId);
            if (bill == null)
            {
                return null;
            }
            return mapper.Map<BillDto>(bill);
        }

        public async Task<IEnumerable<BillDto>> GetBillsByAccount(int accountId)
        {
            var bill = await BillDao.Instance.GetBillsByAccount(accountId);
            return mapper.Map<IEnumerable<BillDto>>(bill);
        }

        public async Task<IEnumerable<BillDto>> GetPaymentHistory(int hiringId)
        {
            var bill = await BillDao.Instance.GetPaymentHistory(hiringId);
            return mapper.Map<IEnumerable<BillDto>>(bill);
        }
    }
}
