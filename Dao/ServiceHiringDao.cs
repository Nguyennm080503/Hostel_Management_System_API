using Common.Enum;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class ServiceHiringDao : BaseDAO<ServiceHostelRoom>
    {
        private static ServiceHiringDao instance = null;
        private static readonly object instacelock = new object();

        private ServiceHiringDao()
        {

        }

        public static ServiceHiringDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceHiringDao();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<ServiceHostelRoom>> GetAllServiceOfCustomer(int accountID)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.ServiceHostelRooms.Include(x => x.Measurement).Where(x => x.AccountID == accountID && x.Status != ServiceHiringStatusEnum.Deleted.ToString()).OrderByDescending(x => x.DateCreate).ToListAsync();
            }
        }
        public async Task<ServiceHostelRoom> GetServiceName(string serviceName, int accountID)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.ServiceHostelRooms.FirstOrDefaultAsync(x => x.ServiceHostelName == serviceName && x.AccountID == accountID && x.Status != ServiceHiringStatusEnum.Deleted.ToString());
            }
        }

        public async Task<ServiceHostelRoom> GetServiceID(int serviceID)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.ServiceHostelRooms.FirstOrDefaultAsync(x => x.ServiceHostelID == serviceID);
            }
        }
    }
}
