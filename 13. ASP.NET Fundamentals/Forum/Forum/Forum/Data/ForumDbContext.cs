using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Forum.Data.Models;

namespace Forum.Data
{
    public class ForumDbContext : IdentityDbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

    }
}