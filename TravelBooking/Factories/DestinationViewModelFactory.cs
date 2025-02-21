using TravelBooking.Models.DBObjects;
using TravelBooking.Models.ViewModels;
using TravelBooking.Repositories;

namespace TravelBooking.Factories
{
    public class DestinationViewModelFactory
    {
        private readonly DestinationRepository _destinationRepository;
        private readonly CityRepository _cityRepository;
        private readonly LocationViewModelFactory _locationViewModelFactory;

        public DestinationViewModelFactory(DestinationRepository destinationRepository, CityRepository cityRepository, LocationViewModelFactory locationViewModelFactory)
        {
            _destinationRepository = destinationRepository;
            _cityRepository = cityRepository;
            _locationViewModelFactory = locationViewModelFactory;
        }

        public DestinationViewModel GetNewDestinationViewModel(Destination destination)
        {
            var city = _cityRepository.GetCityById(destination.CityId);
            var locationViewModel = _locationViewModelFactory.GetNewLocationViewModel(city);

            return new DestinationViewModel
            {
                DestinationId = destination.DestinationId,
                Name = destination.Name,
                Location = locationViewModel.CityName + ", " + locationViewModel.CountryName,
                Description = destination.Description,
                PricePernightPerPerson = destination.PricePernightPerPerson,
                PicturePath = Path.Combine(Directory.GetCurrentDirectory(), destination.Picture)
            };
        }
    }
}
