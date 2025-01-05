using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class MemberHiringDao : BaseDAO<MemberHiringRoom>
    {
        private static MemberHiringDao instance = null;
        private static readonly object instacelock = new object();

        private MemberHiringDao()
        {

        }

        public static MemberHiringDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemberHiringDao();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<MemberHiringRoom>> GetMembersInRoom(int hiringID)
        {
            using (var context = new HostelManagementContext())
            {
                var items = await context.MemberHiringRooms.Where(x => x.HiringRoomHostelID == hiringID ).ToListAsync();
                return items;
            }
        }

        public async Task<MemberHiringRoom> GetMemberInRoom(int memberId)
        {
            using (var context = new HostelManagementContext())
            {
                var items = await context.MemberHiringRooms.Where(x => x.MemberHiringID == memberId).FirstOrDefaultAsync();
                return items;
            }
        }
    }
}
