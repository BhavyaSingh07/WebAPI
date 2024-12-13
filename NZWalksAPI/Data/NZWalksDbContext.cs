using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions) 
        {

        }

        public DbSet<Difficulty> Difficulties   { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks {  get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("E9563FF0-D73D-4470-A25A-A5C1F0D4A2CD"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("D84B719A-E6E3-4EEC-8003-50A954C86188"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("2A821B42-497C-4375-B368-AADC825141E7"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            var region = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("9FEDF87F-41C3-4646-8A91-B5200A8A33E4"),
                    Name = "Auckland",
                    Code = "ACK",
                    RegionImageUrl = "https://imgix.theurbanlist.com/content/article/Rangitoto-Todd-Eyre.-ATEED_RMH_005-(1).jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("6C861A39-F5EE-43E1-A105-C290AAE8361C"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://www.newzealand.com/assets/Tourism-NZ/Northland-Bay-of-Islands/1000011333__aWxvdmVrZWxseQo_FocalPointCropWzM1MiwxMDI0LDMyLDYzLDc1LCJqcGciLDY1LDIuNV0.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("8E9C527F-2F2E-4C77-BDEA-76DCD2DD95CA"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("B950F1F4-DB81-4824-BC58-94B8139B7795"),
                    Name = "Wellington",
                    Code = "WGL",
                    RegionImageUrl = "https://www.neverendingvoyage.com/wp-content/uploads/2022/11/main-wellington-walks-skyline.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("67DFA371-FE56-4EEA-BB4D-308BFB8B7803"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("235B54A5-D6E8-4693-AB4B-F178995B0016"),
                    Name = "SouthLand",
                    Code = "STL",
                    RegionImageUrl = "https://www.newzealand.com/assets/Tourism-NZ/Southland/img-1536309346-4874-7451-B315794E-ED00-E5F3-899FFD38B13A4799__aWxvdmVrZWxseQo_FocalPointCropWzM1MiwxMDI0LDQ5LDYyLDc1LCJqcGciLDY1LDIuNV0.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(region);
        }
    }
}
