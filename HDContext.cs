using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SMARTHardDrive.Models;

namespace SMARTHardDrive
{
    public class HDContext : DbContext
    {
        public DbSet<HardDrive> HardDrives { get; set; }
        public DbSet<SMARTAttribute> SMARTAttributes { get; set; }
        public DbSet<SMARTData> SMARTData { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }

        public HDContext(DbContextOptions<HDContext> options) : base(options)
        {
        }
        public HDContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=HardDrive;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Автозагрузка связанных данных для HardDrive

            modelBuilder.Entity<HardDrive>()
                .Navigation(hd => hd.Maintenances)
                .AutoInclude();

            modelBuilder.Entity<Alert>()
                .Navigation(hd => hd.HardDrives)
                .AutoInclude();

            modelBuilder.Entity<SMARTData>()
                .Navigation(sd => sd.Attribute)
                .AutoInclude();

            modelBuilder.Entity<SMARTData>()
                .Navigation(sd => sd.HardDrive)
                .AutoInclude();

            modelBuilder.Entity<HardDrive>()
                .Property(hd => hd.Status)
                .HasDefaultValue("Активен");

            modelBuilder.Entity<HardDrive>()
                .HasIndex(hd => hd.SerialNumber)
                .IsUnique(false);
        }
        public void AddAlert(string type, string description, DateTime date, string severity, string status, int hardDriveId)
        {
            Database.ExecuteSqlRaw(
                "EXEC AddAlert @Type, @Description, @Date, @Severity, @Status, @HardDriveId",
                new SqlParameter("@Type", type),
                new SqlParameter("@Description", description),
                new SqlParameter("@Date", date),
                new SqlParameter("@Severity", severity),
                new SqlParameter("@Status", status),
                new SqlParameter("@HardDriveId", hardDriveId)
            );
        }
    }
}
