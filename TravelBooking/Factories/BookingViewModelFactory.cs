using System.Globalization;
using TravelBooking.Models.DBObjects;
using TravelBooking.Models.ViewModels;
using TravelBooking.Repositories;

namespace TravelBooking.Factories
{
    public class BookingViewModelFactory
    {
        private readonly BookingRepository _bookingRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly DestinationRepository _destinationRepository;
        private readonly CustomerViewModelFactory _customerViewModelFactory;
        private readonly DestinationViewModelFactory _destinationViewModelFactory;
        private readonly StatusRepository _statusRepository;

        public BookingViewModelFactory(BookingRepository bookingRepository,
            CustomerRepository customerRepository,
            DestinationRepository destinationRepository,
            CustomerViewModelFactory customerViewModelFactory,
            DestinationViewModelFactory destinationViewModelFactory,
            StatusRepository statusRepository)
        {
            _bookingRepository = bookingRepository;
            _customerRepository = customerRepository;
            _destinationRepository = destinationRepository;
            _customerViewModelFactory = customerViewModelFactory;
            _destinationViewModelFactory = destinationViewModelFactory;
            _statusRepository = statusRepository;
        }

        public BookingViewModel GetBookingViewModel(Booking booking)
        {
            var customer = _customerRepository.GetCustomerById(booking.CustomerId);
            var customerViewModel = _customerViewModelFactory.GetNewCustomerViewModel(customer);
            var destination = _destinationRepository.GetDestinationById(booking.DestinationId);
            var destinationViewModel = _destinationViewModelFactory.GetNewDestinationViewModel(destination);
            var status = _statusRepository.GetStatusById(booking.StatusId);
            return new BookingViewModel
            {
                BookingId = booking.BookingId,
                CustomerName = customerViewModel.Name,
                CustomerEmail = customerViewModel.Email,
                CustomerPhone = customerViewModel.Phone,
                DestinationName = destinationViewModel.Name,
                DestinationLocation = destinationViewModel.Location,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                CreatedDate = booking.CreatedDate,
                Status = status.Value,
                Price = booking.Price.ToString("C", CultureInfo.GetCultureInfo("ro-RO")),
                NumberOfPersons = booking.NumberOfPersons
            };
        }
    }
}
