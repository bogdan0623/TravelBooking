using Microsoft.EntityFrameworkCore;
using TravelBooking.Models.DBObjects;
using TravelBooking.Models.ViewModels;

namespace TravelBooking.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public int SaveChanges();
    }
}
