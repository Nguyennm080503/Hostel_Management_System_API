using Dtos.Bill;
using Dtos.Hiring;
using Repository.Interface;
using Service.Exception;
using Service.Interface;

namespace Service.Implement
{
    public class BillPaymentService : IBillPaymentService
    {
        private readonly IBillPaymentRepository repository;
        private readonly IPaymentDetailRepository paymentDetailRepository;
        private readonly IHiringHostelRepository hiringHostelRepository;

        public BillPaymentService(IBillPaymentRepository repository, IPaymentDetailRepository paymentDetailRepository, IHiringHostelRepository hiringHostelRepository)
        {
            this.repository = repository;
            this.paymentDetailRepository = paymentDetailRepository;
            this.hiringHostelRepository = hiringHostelRepository;
        }

        public async Task CreateNewBillPayment(NewBillDto newBill, int accountID)
        {
            var bill = await repository.GetBillPaymentCurrent(newBill.HiringRoomHostelID);
            if (bill != null && bill.DateCreate.Month == new DateTime().Month)
            {
                throw new ServiceException("Tháng này đã tạo hóa đơn. Không thể tạo mới");
            }
            else
            {
                await repository.CreateNewBillPayment(newBill, accountID);
                var billCurrent = await repository.GetBillPaymentCurrent(newBill.HiringRoomHostelID);
                foreach (var item in newBill.BillDetails)
                {
                    if(item.NewNumber != 0)
                    {
                        var serviceLog = new NewServiceLogIndexDto
                        {
                            ServiceLog = (int)item.NewNumber,
                            ServiceHostelID = item.ServiceRoomId,
                            ServiceRoomID = item.ServiceRoomId
                        };
                        await hiringHostelRepository.CreateServiceLogIndex(serviceLog);
                    }
                    await paymentDetailRepository.CreateNewPaymentDetail(item, billCurrent.BillPaymentID);
                }
            }
            return;
        }

        public async Task CreateNewBillPaymentSpending(NewBillPayDto billDto, int accountId)
        {
            await repository.CreateNewBillPaymentSpending(billDto, accountId);
            return;
        }

        public async Task<IEnumerable<BillDto>> GetBillsByAccount(int accountId)
        {
            return await repository.GetBillsByAccount(accountId);
        }

        public async Task<BillDto> GetPaymentDetail(int paymentId)
        {
            var bill = await repository.GetBillPaymentById(paymentId);
            if(bill == null)
            {
                throw new ServiceException("Hóa đơn này không tồn tại !");
            }
            return bill;
        }

        public async Task<IEnumerable<BillDto>> GetPaymentHistory(int hiringId)
        {
            return await repository.GetPaymentHistory(hiringId);
        }
    }
}
