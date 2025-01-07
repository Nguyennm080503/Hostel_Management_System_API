using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Bill;

namespace Repository.Interface
{
    public interface IPaymentDetailRepository
    {
        Task CreateNewPaymentDetail(NewBillDetailDto newBillDetail, int billID);
    }
}
