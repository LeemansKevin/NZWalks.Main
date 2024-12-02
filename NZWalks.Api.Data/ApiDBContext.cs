using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data.Entities;

namespace NZWalks.Api.Data
{
    public class ApiDBContext : DbContext //enige Class die met de DB communiceert
    {
        //Welke tabellen zitter er in de DB
        public DbSet<WalkEntity> Walks { get; set; }

        public DbSet<RegionEntity> Regions { get; set; }

        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegionEntity>().HasData(
                new List<RegionEntity>
    {
                     new RegionEntity
                    {
                        Id= 1,
                        Climate = 1,
                        Name = "White Cap Bay",
                        CreatedOn= DateTime.Now,
                        LastUpdatedOn= DateTime.Now
                     }
    }
    );
            modelBuilder.Entity<WalkEntity>().HasData(
                new List<WalkEntity>
                {
                    new WalkEntity
                    {
                        Id = 1,
                        Altidude = 123,
                        LengthInKm = 10,
                        RegionId = 1,
                        PictureUrl = "www.google.be",
                        CreatedOn= DateTime.Now,
                        Description = "lorem ipsum",
                        Name = "Dummy",
                        Score= 1,
                        LastUpdatedOn= DateTime.Now,
                    },
                     new WalkEntity
                    {
                        Id = 2,
                        Altidude = 6000,
                        LengthInKm = 14,
                        RegionId = 1,
                        PictureUrl = "www.yahoo.be",
                        CreatedOn= DateTime.Now,
                        Description = "lorem",
                        Name = "Another Dummy",
                        Score= 2,
                        LastUpdatedOn= DateTime.Now,
                    }
                });
        }
    }
}