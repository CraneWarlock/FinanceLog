using Microsoft.EntityFrameworkCore;

namespace FinanceLog.Entites
{
    public class FinanceLogDbContext : DbContext 
    {
        private string _connectionString = 
            "Host=localhost;Database=FinanceLogDB;Username=postgres;Password="+getPasswordFromFile();
        public DbSet<FinanceLogs> FinanceLogs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GroupMembers> GroupMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>()
                .Property(r => r.Email)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(r => r.Login)
                .IsRequired()
                .HasMaxLength(50);

            // Group
            modelBuilder.Entity<Group>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Finance Logs
            modelBuilder.Entity<FinanceLogs>()
                .Property(r => r.EntryName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<FinanceLogs>()
                .Property(r => r.Amount)
                .IsRequired();
            modelBuilder.Entity<FinanceLogs>()
                .Property(r => r.DateOfPurchase)
                .IsRequired();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        private static string getPasswordFromFile()
        {
            string password = File.ReadAllText("E:\\password.txt");
            return password;
        }
    }
}
