using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Factories;
using TravelBooking.Models.DBObjects;
using TravelBooking.Repositories;

namespace TravelBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingRepository _bookingRepository;
        private readonly BookingViewModelFactory _bookingViewModelFactory;
        private readonly CustomerRepository _customerRepository;
        private readonly DestinationRepository _destinationRepository;
        private readonly CustomerViewModelFactory _customerViewModelFactory;
        private readonly DestinationViewModelFactory _destinationViewModelFactory;
        private readonly StatusRepository _statusRepository;

        public BookingController(BookingRepository bookingRepository,
            BookingViewModelFactory bookingViewModelFactory,
            CustomerRepository customerRepository,
            DestinationRepository destinationRepository,
            CustomerViewModelFactory customerViewModelFactory,
            DestinationViewModelFactory destinationViewModelFactory,
            StatusRepository statusRepository)
        {
            _bookingRepository = bookingRepository;
            _bookingViewModelFactory = bookingViewModelFactory;
            _customerRepository = customerRepository;
            _destinationRepository = destinationRepository;
            _customerViewModelFactory = customerViewModelFactory;
            _destinationViewModelFactory = destinationViewModelFactory;
            _statusRepository = statusRepository;
        }

        // GET: BookingController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookingController/GetUserBookings/5
        public ActionResult GetUserBookings(Guid id)
        {
            var bookings = _bookingRepository.GetBookingsByCustomer(id).Select(
                _bookingViewModelFactory.GetBookingViewModel).ToList();
            return View(bookings);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateMyBooking(Guid customerId, Guid destinationId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            var destination = _destinationRepository.GetDestinationById(destinationId);
            var customerViewModel = _customerViewModelFactory.GetNewCustomerViewModel(customer);
            var destinationViewModel = _destinationViewModelFactory.GetNewDestinationViewModel(destination);

            //ViewBag.CustomerName = customerViewModel.Name;
            //ViewBag.CustomerEmail = customerViewModel.Email;
            //ViewBag.CustomerPhone = customerViewModel.Phone;
            //ViewBag.DestinationName = destinationViewModel.Name;
            //ViewBag.DestinationLocation = destinationViewModel.Location;

            ViewBag.Customer = customer;
            ViewBag.CustomerViewModel = customerViewModel;
            ViewBag.Destination = destination;
            ViewBag.DestinationViewModel = destinationViewModel;
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMyBooking(IFormCollection collection)
        {
            try
            {
                var destinationId = Guid.Parse(collection["DestinationId"]);
                var destination = _destinationRepository.GetDestinationById(destinationId);
                var destinationPrice = destination.PricePernightPerPerson;
                var numberOfPersons = int.Parse(collection["NumberOfPersons"]);
                var checkIn = DateTime.Parse(collection["CheckIn"]);
                var checkOut = DateTime.Parse(collection["CheckOut"]);
                var numberOfNights = (checkOut - checkIn).Days;
                var totalPrice = destinationPrice * numberOfNights * numberOfPersons;
                var customerId = Guid.Parse(collection["CustomerId"]);
                var booking = new Booking
                {
                    BookingId = Guid.NewGuid(),
                    CustomerId = customerId,
                    DestinationId = Guid.Parse(collection["DestinationId"]),
                    CheckIn = checkIn,
                    CheckOut = checkOut,
                    CreatedDate = DateTime.Now,
                    StatusId = _statusRepository.GetStatusByValue("Pending").StatusId,
                    Price = totalPrice,
                    NumberOfPersons = numberOfPersons
                };
                _bookingRepository.AddBooking(booking);
                return RedirectToAction("GetUserBookings", new { id = customerId });
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
