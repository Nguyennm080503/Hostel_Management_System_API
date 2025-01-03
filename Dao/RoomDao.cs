using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class RoomDao : BaseDAO<Room>
    {
        private static RoomDao instance = null;
        private static readonly object instacelock = new object();

        private RoomDao()
        {

        }

        public static RoomDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomDao();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Room>> GetAllRoomOfHostel(int hostelId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Rooms.Where(x => x.HostelID == hostelId).OrderByDescending(x => x.DateCreate).ToListAsync();
            }
        }
        public async Task<Room> GetRoomName(string roomName, int hostelId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Rooms.FirstOrDefaultAsync(x => x.RoomName == roomName && x.HostelID == hostelId);
            }
        }

        public async Task<Room> GetRoomID(int roomId)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Rooms.FirstOrDefaultAsync(x => x.RoomID == roomId);
            }
        }
    }
}
