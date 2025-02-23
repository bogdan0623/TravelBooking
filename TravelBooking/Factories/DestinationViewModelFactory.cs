using System.Globalization;
using System.Text;
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
        private readonly ImageRepository _imageRepository;

        public DestinationViewModelFactory(DestinationRepository destinationRepository, CityRepository cityRepository, LocationViewModelFactory locationViewModelFactory, ImageRepository imageRepository)
        {
            _destinationRepository = destinationRepository;
            _cityRepository = cityRepository;
            _locationViewModelFactory = locationViewModelFactory;
            _imageRepository = imageRepository;
        }

        public DestinationViewModel GetNewDestinationViewModel(Destination destination)
        {
            var city = _cityRepository.GetCityById(destination.CityId);
            var locationViewModel = _locationViewModelFactory.GetNewLocationViewModel(city);
            var images = _imageRepository.GetImagesByDestination(destination);
            var imagesNames = new List<string>();
            var stringBuilder = new StringBuilder();
            foreach (var image in images)
            {
                stringBuilder.Clear();
                stringBuilder.Append("/images/");
                stringBuilder.Append(image.Name);
                imagesNames.Add(stringBuilder.ToString());
            }
            
            imagesNames.Sort();

            return new DestinationViewModel
            {
                DestinationId = destination.DestinationId,
                Name = destination.Name,
                Location = locationViewModel.CityName + ", " + locationViewModel.CountryName,
                Description = destination.Description,
                PricePernightPerPerson = destination.PricePernightPerPerson.ToString("C", CultureInfo.GetCultureInfo("ro-RO")),
                ImagesNames = imagesNames
            };
        }
    }
}
