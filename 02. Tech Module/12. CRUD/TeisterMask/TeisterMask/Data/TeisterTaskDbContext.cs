using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeisterMask.Models;

namespace TeisterMask.Data
{
    public class TeisterTaskDbContext : DbContext
    {
        string conn = @"Server=localhost\SQLEXPRESS;Database=Meister;Trusted_Connection=True;";

        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conn);
        }
    }
}
