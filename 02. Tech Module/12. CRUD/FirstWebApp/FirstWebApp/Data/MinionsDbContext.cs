namespace FirstWebApp.Data
{
    using FirstWebApp.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MinionsDbContext : DbContext
    {
        private const string Conn = "Server=localhost\\SQLEXPRESS;Database=Despicable;Trusted_Connection=True;";

        public virtual DbSet<Minion> Minions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Conn);
        }
    }
}
