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
    public class HiringHostelDao : BaseDAO<HiringRoomHostel>
    {
        private static HiringHostelDao instance = null;
        private static readonly object instacelock = new object();

        private HiringHostelDao()
        {

        }

        public static HiringHostelDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HiringHostelDao();
                }
                return instance;
            }
        }

        public async Task<HiringRoomHostel> GetHiringHostelCurrent(int roomId)
        {
            using (var context = new HostelManagementContext())
            {
                var items = await context.HiringRoomHostels.Where(x => x.RoomID == roomId && x.Status == HiringStatusEnum.Hiring.ToString()).OrderByDescending(x => x.DateCreate).FirstOrDefaultAsync();
                return items;
            }
        }

        public async Task<IEnumerable<HiringRoomHostel>> GetAllHiringsHistory(int roomId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.HiringRoomHostels.Where(x => x.RoomID == roomId && x.Status != HiringStatusEnum.Deleted.ToString()).OrderByDescending(x => x.DateCreate).ToListAsync();
            }
        }

        public async Task<HiringRoomHostel> GetHiringByID(int hiringId)
        {
            using (var context = new HostelManagementContext())
            {
                var items = await context.HiringRoomHostels.Where(x => x.HiringRoomHostelID == hiringId).FirstOrDefaultAsync();
                return items;
            }
        }
    }
}
