using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class RoomServiceDao : BaseDAO<HiringService>
    {
        private static RoomServiceDao instance = null;
        private static readonly object instacelock = new object();

        private RoomServiceDao()
        {

        }

        public static RoomServiceDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomServiceDao();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<HiringService>> GetAllServiceOfRoom(int hiringId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.HiringServices.Include(x => x.ServiceHostelRoom).ThenInclude(x => x.Measurement).Include(x => x.ServiceLogIndices).Where(x => x.HiringRoomHostelID == hiringId).ToListAsync();
            }
        }

        public async Task<HiringService> GetServiceByCurrent(int serviceID, int roomId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.HiringServices.Where(x => x.ServiceHostelRoomID == serviceID && x.HiringRoomHostelID == roomId).OrderByDescending(x => x.HiringServiceID).FirstOrDefaultAsync();
            }
        }
    }
}
