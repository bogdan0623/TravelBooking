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
