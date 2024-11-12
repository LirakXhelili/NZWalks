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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed data for Difficulties 
            //Easy, Medium , Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("df0d7d14-d835-46e8-9c54-76670ef57cef"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("63f368c1-ff89-4f0a-88f6-f538ba89c229"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("710fa13d-40e7-4694-8816-22944a1e4bd1"),
                    Name = "Hard"
                }
            };
            //Seed Dificulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Regions
            var regions = new List<Region>()
            {
                new Region() {
                    Id= Guid.Parse("3a9f591c-7c9e-457c-87aa-766b8665b98c"),
                    Name = "AuckLand",
                    Code = "Auk",
                    RegionImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSgQt4gkKebi36jCQ6Bi1bVWYRybLEs-Vm2AA&s"
                },
                new Region() {
                    Id= Guid.Parse("96e1007c-f6b5-43b2-bbd5-4f6cd679a107"),
                    Name = "Gjilan",
                    Code = "06",
                    RegionImageUrl = "https://kallxo.com/wp-content/uploads/2020/11/GJILANI-DRON-1-720x405.png"
                },
                new Region() {
                    Id= Guid.Parse("d9fc392b-218a-4842-b6a5-1118af631336"),
                    Name = "Prishtina",
                    Code = "01",
                    RegionImageUrl = "https://www.albinfo.at/wp-content/uploads/2021/07/210644935_4230753403630675_6342664394500292046_n.jpg"
                },
                new Region() {
                    Id= Guid.Parse("f97e90b4-6303-4da1-96f8-f2c850cbed97"),
                    Name = "Mitrovice",
                    Code = "02",
                    RegionImageUrl = "https://i0.wp.com/mytravelation.com/wp-content/uploads/2023/12/Mitrovica-Kosovo.jpg"
                }
            };

            //Seed regions
            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
