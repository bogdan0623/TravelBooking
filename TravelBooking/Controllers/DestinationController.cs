using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelBooking.Factories;
using TravelBooking.Models.DBObjects;
using TravelBooking.Models.ViewModels;
using TravelBooking.Repositories;

namespace TravelBooking.Controllers
{
    public class DestinationController : Controller
    {   
        private readonly DestinationRepository _destinationRepository;
        private readonly DestinationViewModelFactory _destinationViewModelFactory;
        private readonly CountryRepository _countryRepository;
        private readonly CityRepository _cityRepository;
        private readonly CustomerRepository _customerRepository;

        public DestinationController(DestinationRepository destinationRepository, DestinationViewModelFactory destinationViewModelFactory, CountryRepository countryRepository, CityRepository cityRepository, CustomerRepository customerRepository)
        {
            _destinationRepository = destinationRepository;
            _destinationViewModelFactory = destinationViewModelFactory;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _customerRepository = customerRepository;
        }

        // GET: DestinationController
        public ActionResult Index(string? cityName)
        {
            if(!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            var destinations = new List<DestinationViewModel>();
            if (cityName == null)
            {
                destinations = _destinationRepository.GetDestinations().Select(
                    _destinationViewModelFactory.GetNewDestinationViewModel).ToList();
            }
            else
            {                
                destinations = _destinationRepository.GetDestinationsByLocation(cityName).Select(
                    _destinationViewModelFactory.GetNewDestinationViewModel).ToList();
            }

            ViewBag.CityName = cityName;
            return View(destinations);
        }

        public ActionResult Search()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }
            ViewBag.Countries = _countryRepository.GetCountries();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(IFormCollection collection)
        {
            try
            {
                var c = collection;
                var cityName = _cityRepository.GetCityById(Guid.Parse(collection["CityId"]))?.Name ?? "undefined";
                return RedirectToAction("Index", new { cityName });
                
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetCitiesByCountry(Guid countryId)
        {
            var cities = _cityRepository.GetCitiesByCountry(countryId).Select(city => new
            {
                CityId = city.CityId,
                Name = city.Name
            }).ToList();
            return Json(cities);
        }

        // GET: DestinationController/Details/5
        public ActionResult Details(Guid id, string cityName)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            var destinationViewModel = _destinationViewModelFactory.GetNewDestinationViewModel(
                _destinationRepository.GetDestinationById(id)); 
            ViewBag.CityName = cityName;
            var email = User.Identity.Name;
            ViewBag.Customer = _customerRepository.GetCustomerByEmail(email);
            return View(destinationViewModel);
        }

        // GET: DestinationController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DestinationController/Create
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

        // GET: DestinationController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DestinationController/Edit/5
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

        // GET: DestinationController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DestinationController/Delete/5
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
