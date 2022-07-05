using Microsoft.EntityFrameworkCore;
using WeatherTrackingApi.Models;

namespace WeatherTrackingApi.Data
{
    public class WeatherTrackingDbContext : DbContext
    {
        public WeatherTrackingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<BookingSchedule> BookingSchedules { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<FavoriteDestination> FavoriteDestinations { get; set; }
        public DbSet<SuggestBoard> SuggestBoards { get; set; }
        public DbSet<SuggestBoardImage> SuggestBoardImages { get; set; }
        public DbSet<TransportHistory> TransportHistories { get; set; }
        public DbSet<WeatherStatus> WeatherStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FavoriteDestination>().HasKey(f => new { f.UserId, f.CityId });
        }
    }
}