using TravelBooking.Data;
using TravelBooking.Models.DBObjects;

namespace TravelBooking.Repositories
{
    public class CityRepository
    {
        private ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.ToList();
        }

        public IEnumerable<City> GetCitiesByCountry(Guid countryId)
        {
            return _context.Cities
                .Where(c => c.CountryId == countryId)
                .ToList();
        }

        public City GetCityById(Guid id)
        {
            return _context.Cities.FirstOrDefault(c => c.CityId == id);
        }

        public City GetCityByName(string name)
        {
            return _context.Cities.FirstOrDefault(c => c.Name == name);
        }

        public void AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        public void UpdateCity(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }

        public void DeleteCity(Guid id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.CityId == id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
            }
        }
    }
}
