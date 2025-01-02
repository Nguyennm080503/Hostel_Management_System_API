using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class MeasurementDao : BaseDAO<Measurement>
    {
        private static MeasurementDao instance = null;
        private static readonly object instacelock = new object();

        private MeasurementDao()
        {

        }

        public static MeasurementDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MeasurementDao();
                }
                return instance;
            }
        }

        public override async Task<IEnumerable<Measurement>> GetAllAsync()
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Measurements.OrderByDescending(x => x.MeasurementID).ToListAsync();
            }
        }
        public async Task<Measurement> GetMeasuremnetName(string measurementName)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Measurements.FirstOrDefaultAsync(x => x.MeasurementName == measurementName);
            }
        }

        public async Task<Measurement> GetMeasurementID(int measurementID)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Measurements.FirstOrDefaultAsync(x => x.MeasurementID == measurementID);
            }
        }
    }
}
