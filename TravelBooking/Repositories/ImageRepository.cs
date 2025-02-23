using TravelBooking.Data;
using TravelBooking.Models.DBObjects;

namespace TravelBooking.Repositories
{
    public class ImageRepository
    {
        private ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Image> GetImages()
        {
            return _context.Images.ToList();
        }

        public IEnumerable<Image> GetImagesByDestination(Destination destination)
        {
            return _context.Images
                .Where(x => x.DestinationId == destination.DestinationId)
                .ToList();
        }

        public Image GetImageById(Guid id)
        {
            return _context.Images.FirstOrDefault(x => x.ImageId == id);
        }
    }
}
