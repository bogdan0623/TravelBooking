using TravelBooking.Data;
using TravelBooking.Models.DBObjects;

namespace TravelBooking.Repositories
{
    public class DestinationRepository
    {
        private ApplicationDbContext _context;

        public DestinationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Destination> GetDestinations()
        {
            return _context.Destinations.ToList();
        }

        public IEnumerable<Destination> GetDestinationsByLocation(string cityName)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Name == cityName);
            return _context.Destinations
                .Where(x => x.CityId == city.CityId).ToList();
        }

        public Destination GetDestinationById(Guid id)
        {
            return _context.Destinations.FirstOrDefault(x => x.DestinationId == id);
        }

        public void AddDestination(Destination destination)
        {
            _context.Destinations.Add(destination);
            _context.SaveChanges();
        }

        public void UpdateDestination(Destination destination)
        {
            _context.Destinations.Update(destination);
            _context.SaveChanges();
        }

        public void DeleteDestination(Guid id)
        {
            var destination = _context.Destinations.FirstOrDefault(y => y.DestinationId == id);
            if (destination != null)
            {
                _context.Destinations.Remove(destination);
                _context.SaveChanges();
            }
        }
    }
}
