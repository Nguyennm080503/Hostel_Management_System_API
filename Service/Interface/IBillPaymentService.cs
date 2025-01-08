using Dtos.Bill;

namespace Service.Interface
{
    public interface IBillPaymentService
    {
        Task CreateNewBillPayment(NewBillDto newBill, int accountID);
        Task CreateNewBillPaymentSpending(NewBillPayDto billDto, int accountId);
        Task<IEnumerable<BillDto>> GetBillsByAccount(int accountId);
        Task<BillDto> GetPaymentDetail(int paymentId);
        Task<IEnumerable<BillDto>> GetPaymentHistory(int hiringId);
    }
}
