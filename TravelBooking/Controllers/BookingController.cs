using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Factories;
using TravelBooking.Models.DBObjects;
using TravelBooking.Models.ViewModels;
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
        public ActionResult Details(Guid id)
        {
            var booking = _bookingRepository.GetBookingById(id);
            var bookingViewModel = _bookingViewModelFactory.GetBookingViewModel(booking);
            var numberOfNights = (booking.CheckOut - booking.CheckIn).Days;
            ViewBag.CustomerId = booking.CustomerId;
            ViewBag.NumberOfNights = numberOfNights;
            return View(bookingViewModel);
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
                var booking = new Booking();
                booking.BookingId = Guid.NewGuid();
                booking.CustomerId = Guid.Parse(collection["CustomerId"]);
                booking.DestinationId = Guid.Parse(collection["DestinationId"]);

                var checkIn = GetNullOrValidDateTime(collection["CheckIn"]);
                if(checkIn == null)
                {
                    ModelState.AddModelError("CheckIn", "Check-in date is not valid!");
                    throw new Exception("Check-in date is not valid!");
                }
                booking.CheckIn = checkIn.Value;

                var checkOut = GetNullOrValidDateTime(collection["CheckOut"]);
                if (checkOut == null)
                {
                    ModelState.AddModelError("CheckOut", "Check-out date is not valid!");
                    throw new Exception("Check-out date is not valid!");
                }
                booking.CheckOut = checkOut.Value;

                var now = DateTime.Now;
                booking.CreatedDate = now;
                booking.LastModifiedDate = now;
                booking.StatusId = _statusRepository.GetStatusByValue("Pending").StatusId;

                if (string.IsNullOrWhiteSpace(collection["NumberOfPersons"]))
                {
                    ModelState.AddModelError("NumberOfPersons", "This field is required.");
                    throw new Exception("The NumberOfPersons field is required.");
                }

                if (booking.CheckIn >= booking.CheckOut)
                {
                    ModelState.AddModelError("CheckOut", "Check-out date must be after check-in date!");
                    throw new Exception("Check-out date must be after check-in date!");
                }

                booking.NumberOfPersons = int.Parse(collection["NumberOfPersons"]);

                var destination = _destinationRepository.GetDestinationById(booking.DestinationId);
                var destinationPrice = destination.PricePernightPerPerson;
                var numberOfNights = (booking.CheckOut - booking.CheckIn).Days;
                var totalPrice = destinationPrice * numberOfNights * booking.NumberOfPersons;                

                var customer = _customerRepository.GetCustomerById(booking.CustomerId);
                var customerViewModel = _customerViewModelFactory.GetNewCustomerViewModel(customer);
                var destinationViewModel = _destinationViewModelFactory.GetNewDestinationViewModel(destination);                

                booking.Price = totalPrice;
                _bookingRepository.AddBooking(booking);
                return RedirectToAction("GetUserBookings", new { id = booking.CustomerId });
            }
            catch(Exception)
            {
                var customerId = Guid.Parse(collection["CustomerId"]);
                var destinationId = Guid.Parse(collection["DestinationId"]);
                var destination = _destinationRepository.GetDestinationById(destinationId);

                var customer = _customerRepository.GetCustomerById(customerId);
                var customerViewModel = _customerViewModelFactory.GetNewCustomerViewModel(customer);
                var destinationViewModel = _destinationViewModelFactory.GetNewDestinationViewModel(destination);

                ViewBag.Customer = customer;
                ViewBag.CustomerViewModel = customerViewModel;
                ViewBag.Destination = destination;
                ViewBag.DestinationViewModel = destinationViewModel;
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var booking = _bookingRepository.GetBookingById(id);
            var bookingViewModel = _bookingViewModelFactory.GetBookingViewModel(booking);

            var destination = _destinationRepository.GetDestinationById(booking.DestinationId);
            ViewBag.Destination = destination;

            return View(bookingViewModel);
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var booking = _bookingRepository.GetBookingById(id);

                var checkIn = GetNullOrValidDateTime(collection["CheckIn"]);
                var checkOut = GetNullOrValidDateTime(collection["CheckOut"]);
                if (checkIn == null)
                {
                    ModelState.AddModelError("CheckIn", "Check-in date is not valid!");
                    throw new Exception("Check-in date is not valid!");
                }
                if (checkOut == null)
                {
                    ModelState.AddModelError("CheckOut", "Check-out date is not valid!");
                    throw new Exception("Check-out date is not valid!");
                }
                if (checkIn >= checkOut)
                {
                    ModelState.AddModelError("CheckOut", "Check-out date must be after check-in date!");
                    throw new Exception("Check-out date must be after check-in date!");
                }

                if (string.IsNullOrWhiteSpace(collection["NumberOfPersons"]))
                {
                    ModelState.AddModelError("NumberOfPersons", "This field is required.");
                    throw new Exception("The NumberOfPersons field is required.");
                }
                var isValid = int.TryParse(collection["NumberOfPersons"], out var numberOfPersons);
                if(!isValid || (isValid && numberOfPersons <= 0))
                {
                    ModelState.AddModelError("NumberOfPersons", "This field is invalid.");
                    throw new Exception("The NumberOfPersons field is invalid.");
                }


                booking.CheckIn = checkIn.Value;
                booking.CheckOut = checkOut.Value;
                booking.LastModifiedDate = DateTime.Now;
                booking.StatusId = _statusRepository.GetStatusByValue("Pending").StatusId;
                booking.NumberOfPersons = numberOfPersons;
                booking.Price = decimal.Parse(collection["Price"]);
                _bookingRepository.UpdateBooking(booking);

                return RedirectToAction("GetUserBookings", new { id = booking.CustomerId });
            }
            catch(Exception e)
            {
                var booking = _bookingRepository.GetBookingById(id);
                var bookingViewModel = _bookingViewModelFactory.GetBookingViewModel(booking);

                var destination = _destinationRepository.GetDestinationById(booking.DestinationId);
                ViewBag.Destination = destination;
                return View(bookingViewModel);
            }
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var booking = _bookingRepository.GetBookingById(id);
            var bookingViewModel = _bookingViewModelFactory.GetBookingViewModel(booking);
            return View(bookingViewModel);
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var booking = _bookingRepository.GetBookingById(id);
                var customerId = booking.CustomerId;
                _bookingRepository.DeleteBooking(id);
                return RedirectToAction("GetUserBookings", new { id = customerId });
            }
            catch
            {
                return View();
            }
        }

        //[AcceptVerbs("GET", "POST")]
        //public ActionResult ValidateDates(string CheckIn, string CheckOut)
        //{
        //    var start = GetNullOrValidDateTime(CheckIn);
        //    var end = GetNullOrValidDateTime(CheckOut);

        //    if (start == null)
        //    {
        //        return Json("Check-in is invalid!");
        //    }

        //    if (end == null)
        //    {
        //        return Json("Check-out is invalid!");
        //    }

        //    if (start > end)
        //    {
        //        return Json("Check-out date must be after check-in date!");
        //    }

        //    return Json(true);
        //}

        private DateTime? GetNullOrValidDateTime(string dateTimeString)
        {
            if (string.IsNullOrWhiteSpace(dateTimeString))
            {
                return null;
            }

            var isValid = DateTime.TryParse(dateTimeString, out var result);
            return isValid ? result : null;
        }
    }
}
