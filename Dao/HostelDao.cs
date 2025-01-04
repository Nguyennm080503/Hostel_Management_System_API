using Common.Enum;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class HostelDao : BaseDAO<Hostel>
    {
        private static HostelDao instance = null;
        private static readonly object instacelock = new object();

        private HostelDao()
        {

        }

        public static HostelDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HostelDao();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Hostel>> GetAllHostelsOfCustomer(int accountID)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Hostels.Where(x => x.AccountID == accountID && x.Status != HostelStatusEnum.Deleted.ToString()).OrderByDescending(x => x.HostelID).ToListAsync();
            }
        }
        public async Task<Hostel> GetHostelName(string hostelName, int accountID)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Hostels.FirstOrDefaultAsync(x => x.HostelName == hostelName && x.AccountID == accountID && x.Status != HostelStatusEnum.Deleted.ToString());
            }
        }

        public async Task<Hostel> GetHostelID(int hostelID)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Hostels.FirstOrDefaultAsync(x => x.HostelID == hostelID);
            }
        }
    }
}
