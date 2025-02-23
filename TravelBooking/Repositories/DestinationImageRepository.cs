using TravelBooking.Data;
using TravelBooking.Models.DBObjects;

namespace TravelBooking.Repositories
{
    public class DestinationImageRepository
    {
        private ApplicationDbContext _context;

        public DestinationImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DestinationImage> GetDestinationImagesByDestination(Destination destination)
        {
            return _context.DestinationsImages
                .Where(d => d.DestinationId == destination.DestinationId)
                .ToList();
        }
    }
}
