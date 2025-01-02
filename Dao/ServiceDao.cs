using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class ServiceDao : BaseDAO<Service>
    {
        private static ServiceDao instance = null;
        private static readonly object instacelock = new object();

        private ServiceDao()
        {

        }

        public static ServiceDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceDao();
                }
                return instance;
            }
        }
        public override async Task<IEnumerable<Service>> GetAllAsync()
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Services.OrderByDescending(x => x.ServiceID).ToListAsync();
            }
        }

        public async Task<Service> GetServiceName(string serviceName)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Services.FirstOrDefaultAsync(x => x.ServiceName == serviceName);
            }
        }

        public async Task<Service> GetServiceID(int serviceID)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Services.FirstOrDefaultAsync(x => x.ServiceID == serviceID);
            }
        }
    }
}
