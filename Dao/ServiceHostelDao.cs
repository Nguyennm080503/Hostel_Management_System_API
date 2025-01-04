using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class ServiceHostelDao : BaseDAO<ServiceHostel>
    {
        private static ServiceHostelDao instance = null;
        private static readonly object instacelock = new object();

        private ServiceHostelDao()
        {

        }

        public static ServiceHostelDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceHostelDao();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<ServiceHostel>> GetAllServiceOfCustomer(int hostelID)
        {
            using (var context = new HostelManagementContext())
            {
                var items = await context.ServiceHostels.Include(x => x.ServiceHostelRoom).ThenInclude(room => room.Measurement).Where(x => x.HostelID == hostelID).ToListAsync();
                return items;
            }
        }

        public async Task<ServiceHostel> GetServiceID(int serviceID)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.ServiceHostels.FirstOrDefaultAsync(x => x.HiringServiceHostelID == serviceID);
            }
        }

        public async Task<ServiceHostel> GetServiceRoomExisted(int serviceID, int hostelId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.ServiceHostels.FirstOrDefaultAsync(x => x.ServiceHostelRoomID == serviceID && x.HostelID == hostelId);
            }
        }
    }
}
