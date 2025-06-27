using CompanyRecords.API.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CompanyRecords.API.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Company>().ToTable("Companies").HasIndex(x => x.Isin).IsUnique();

            modelBuilder.Entity<Company>().HasData(
                
                new Company
                {
                    Id = 1,
                    Name = "Apple Inc.",
                    Exchange = "NASDAQ",
                    Ticker = "AAPL",
                    Isin = "US0378331005",
                    WebsiteUrl = "http://www.apple.com"
                },
                new Company
                {
                    Id = 2,
                    Name = "British Airways Plc",
                    Exchange = "Pink Sheets",
                    Ticker = "BAIRY",
                    Isin = "US1104193065",
                    WebsiteUrl = null
                },
                new Company
                {
                    Id = 3,
                    Name = "Heineken NV",
                    Exchange = "Euronext Amsterdam",
                    Ticker = "HEIA",
                    Isin = "NL0000009165",
                    WebsiteUrl = null
                },
                new Company
                {
                    Id = 4,
                    Name = "Panasonic Corp",
                    Exchange = "Tokyo Stock Exchange",
                    Ticker = "6752",
                    Isin = "JP3866800000",
                    WebsiteUrl = "http://www.panasonic.co.jp"
                },
                new Company
                {
                    Id = 5,
                    Name = "Porsche Automobil",
                    Exchange = "Deutsche Börse",
                    Ticker = "PAH3",
                    Isin = "DE000PAH0038",
                    WebsiteUrl = "https://www.porsche.com/"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
