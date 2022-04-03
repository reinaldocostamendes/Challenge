using Microsoft.EntityFrameworkCore;
using Challenge.Models;

namespace Challenge.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<VeryBigSum> VeryBigSums { get; set; }
        public DbSet<DiagonalSum> DiagonalSums { get; set; }    
        public DbSet<RatioElements> RatioElements { get; set; } 
    }
}
