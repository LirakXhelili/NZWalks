using Microsoft.EntityFrameworkCore;
using NEZWalksAPI.Models.Domain;

namespace NEZWalksAPI.Data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContexOption):base(dbContexOption)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions{ get; set; }
        public DbSet<Walk>Walk { get; set; }

    }
}
