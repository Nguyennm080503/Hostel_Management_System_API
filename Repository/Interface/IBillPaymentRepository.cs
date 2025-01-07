using Dtos.Bill;

namespace Repository.Interface
{
    public interface IBillPaymentRepository
    {
        Task CreateNewBillPayment(NewBillDto newBill, int accountID);
        Task<BillDto> GetBillPaymentCurrent(int hiringId);
        Task<BillDto> GetBillPaymentById(int billId);
        Task<IEnumerable<BillDto>> GetPaymentHistory(int hiringId);
    }
}
