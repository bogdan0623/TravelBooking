using TravelBooking.Models.DBObjects;
using TravelBooking.Models.ViewModels;
using TravelBooking.Repositories;

namespace TravelBooking.Factories
{
    public class LocationViewModelFactory
    {
        private readonly CityRepository _cityRepository;
        private readonly CountryRepository _countryRepository;

        public LocationViewModelFactory(CountryRepository countryRepository, CityRepository cityRepository)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }

        public LocationViewModel GetNewLocationViewModel(City city)
        {
            var country = _countryRepository.GetCountryById(city.CountryId);
            return new LocationViewModel
            {
                CityName = city.Name,
                CountryName = country.Name
            };
        }

        public LocationViewModel GetNewLocationViewModel(string cityName)
        {
            var city = _cityRepository.GetCityByName(cityName);
            return GetNewLocationViewModel(city);
        }
    }
}
