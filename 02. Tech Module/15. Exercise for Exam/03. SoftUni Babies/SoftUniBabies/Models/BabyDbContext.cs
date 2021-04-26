namespace SoftUniBabies.Models
{
    using Microsoft.EntityFrameworkCore;

    public class BabyDbContext : DbContext
    {
        public DbSet<Baby> Babies { get; set; }

        public BabyDbContext()
        {
            this.Database.EnsureCreated();
        }
        string conn = @"Server = localhost\SQLEXPRESS;Database=softunibabies;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conn);
        }
    }
}
