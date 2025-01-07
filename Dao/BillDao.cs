using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enum;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class BillDao : BaseDAO<BillPayment>
    {
        private static BillDao instance = null;
        private static readonly object instacelock = new object();

        private BillDao()
        {

        }

        public static BillDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDao();
                }
                return instance;
            }
        }

        public async Task<BillPayment> GetBillCurrent(int hiringId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.BillPayments.Include(x => x.BillInformation).Where(x => x.HiringRoomHostelID == hiringId).OrderByDescending(x => x.DateCreate).FirstOrDefaultAsync();
            }
        }

        public async Task<BillPayment> GetBillByID(int billId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.BillPayments
                    .Include(x => x.BillInformation)
                    .Include(x => x.HiringRoomHostel)
                        .ThenInclude(x => x.Hostel)
                    .Include(x => x.HiringRoomHostel)
                        .ThenInclude(x => x.Room)
                    .Where(x => x.BillPaymentID == billId).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<BillPayment>> GetPaymentHistory(int hiringId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.BillPayments.Include(x => x.BillInformation).Where(x => x.HiringRoomHostelID == hiringId).OrderByDescending(x => x.DateCreate).ToListAsync();
            }
        }
    }
}
