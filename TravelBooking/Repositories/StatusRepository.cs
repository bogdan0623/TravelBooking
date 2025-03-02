using TravelBooking.Data;
using TravelBooking.Models.DBObjects;

namespace TravelBooking.Repositories
{
    public class StatusRepository
    {
        private ApplicationDbContext _context;

        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _context.Statuses.ToList();
        }

        public Status GetStatusById(int id)
        {
            return _context.Statuses.FirstOrDefault(s => s.StatusId == id);
        }

        public Status GetStatusByValue(string status)
        {
            return _context.Statuses.FirstOrDefault(s => s.Value == status);
        }

        public void AddStatus(Status status)
        {
            _context.Statuses.Add(status);
            _context.SaveChanges();
        }

        public void UpdateStatus(Status status)
        {
            _context.Statuses.Update(status);
            _context.SaveChanges();
        }

        public void DeleteStatus(int id)
        {
            var status = _context.Statuses.FirstOrDefault(s => s.StatusId == id);
            if (status != null)
            {
                _context.Statuses.Remove(status);
                _context.SaveChanges();
            }
        }
    }
}
