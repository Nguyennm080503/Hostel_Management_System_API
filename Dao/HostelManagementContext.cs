using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace Dao
{
    public class HostelManagementContext : DbContext
    {
        public HostelManagementContext()
        {
        }

        public HostelManagementContext(DbContextOptions<HostelManagementContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HiringRoomHostel> HiringRoomHostels { get; set; }
        public DbSet<HiringService> HiringServices { get; set; }
        public DbSet<HiringPayment> HiringPayments { get; set; }
        public DbSet<BillPayment> BillPayments { get; set; }
        public DbSet<BillInformation> BillInformations { get; set; }
        public DbSet<ServiceHostelRoom> ServiceHostelRooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var strConn = config["ConnectionStrings:DefaultConnection"];

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
               .HasMany(a => a.Hostels)
               .WithOne(h => h.AccountOwner)
               .HasForeignKey(h => h.AccountID)
               .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Account>()
                .HasMany(a => a.HiringRoomOwner)
                .WithOne(h => h.AccountOwner)
                .HasForeignKey(h => h.AccountOwnerID)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Account>()
                .HasMany(a => a.HiringRoomHostels)
                .WithOne(h => h.AccountHiring)
                .HasForeignKey(h => h.AccountHiringID)
                .OnDelete(DeleteBehavior.NoAction);

            // Hostels and Rooms
            modelBuilder.Entity<Hostel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hostel)
                .HasForeignKey(r => r.HostelID)
                .OnDelete(DeleteBehavior.Cascade);

            // HiringRoomHostel relationships
                modelBuilder.Entity<HiringRoomHostel>()
             .HasOne(h => h.AccountOwner)
             .WithMany()
             .HasForeignKey(h => h.AccountOwnerID)
             .OnDelete(DeleteBehavior.NoAction); // No cascading delete for AccountOwner to HiringRoomHostel

            modelBuilder.Entity<HiringRoomHostel>()
                .HasOne(h => h.Hostel)
                .WithMany()
                .HasForeignKey(h => h.HostelID)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete from Hostel to HiringRoomHostel

            modelBuilder.Entity<HiringRoomHostel>()
                .HasOne(h => h.Room)
                .WithMany(r => r.HiringRoomHostels)
                .HasForeignKey(h => h.RoomID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete from Room to HiringRoomHostel if needed

            modelBuilder.Entity<HiringRoomHostel>()
                .HasOne(h => h.AccountHiring)
                .WithMany()
                .HasForeignKey(h => h.AccountHiringID)
                .OnDelete(DeleteBehavior.NoAction);

            // HiringService relationships
            modelBuilder.Entity<HiringService>()
                .HasOne(hs => hs.HiringRoomHostel)
                .WithMany(h => h.HiringServices)
                .HasForeignKey(hs => hs.HiringRoomHostelID)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

            modelBuilder.Entity<HiringService>()
                .HasOne(hs => hs.ServiceHostelRoom)
                .WithMany(shr => shr.HiringServices)
                .HasForeignKey(hs => hs.ServiceHostelRoomID)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

            // BillPayment relationships
            modelBuilder.Entity<BillPayment>()
                .HasOne(bp => bp.AccountCreate)
                .WithMany()
                .HasForeignKey(bp => bp.AccountCreateID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BillPayment>()
                .HasOne(bp => bp.HiringPayment)
                .WithMany()
                .HasForeignKey(bp => bp.HiringPaymentID)
                .OnDelete(DeleteBehavior.NoAction);

            // BillInformation relationships
            modelBuilder.Entity<BillInformation>()
                .HasOne(bi => bi.BillPayment)
                .WithMany(bp => bp.BillInformation)
                .HasForeignKey(bi => bi.BillPaymentID)
                .OnDelete(DeleteBehavior.NoAction);

            // ServiceHostelRoom relationships
            modelBuilder.Entity<ServiceHostelRoom>()
                .HasKey(shr => shr.ServiceHostelID); // Define primary key

            modelBuilder.Entity<ServiceHostelRoom>()
                .HasOne(shr => shr.Measurement)
                .WithMany()
                .HasForeignKey(shr => shr.MeasurementID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
