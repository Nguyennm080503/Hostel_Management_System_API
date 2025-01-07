using AutoMapper;
using Dao;
using Dtos.Bill;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class PaymentDetailRepository : IPaymentDetailRepository
    {
        private readonly IMapper mapper;
        public PaymentDetailRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task CreateNewPaymentDetail(NewBillDetailDto newBillDetail, int billId)
        {
            var billDetail = mapper.Map<BillInformation>(newBillDetail);
            billDetail.BillPaymentID = billId;
            await BillDetailDao.Instance.CreateAsync(billDetail);
            return;
        }
    }
}
