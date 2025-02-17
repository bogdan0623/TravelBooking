using TravelBooking.Data;
using TravelBooking.Models.DBObjects;

namespace TravelBooking.Repositories
{
    public class CountryRepository
    {
        private ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(Guid id)
        {
            return _context.Countries.FirstOrDefault(c => c.CountryId == id);
        }

        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public void DeleteCountry(Guid id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.CountryId == id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
        }
    }
}
