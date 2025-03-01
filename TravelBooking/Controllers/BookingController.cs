using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Factories;
using TravelBooking.Repositories;

namespace TravelBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingRepository _bookingRepository;
        private readonly BookingViewModelFactory _bookingViewModelFactory;

        public BookingController(BookingRepository bookingRepository, BookingViewModelFactory bookingViewModelFactory)
        {
            _bookingRepository = bookingRepository;
            _bookingViewModelFactory = bookingViewModelFactory;
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
