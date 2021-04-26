using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using CatShop.Models;

namespace CatShop.Data
{
    public class CatDbContext : DbContext
    {
        string conn = @"Server=localhost\SQLEXPRESS;Database=Meister;Trusted_Connection=True;";

        public virtual DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conn);
        }
    }
}