using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Models;
using TravelBooking.Repositories;

namespace TravelBooking.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryRepository _countryRepository;

        public CountryController(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // GET: CountryController
        public ActionResult Index()
        {
            var countries = _countryRepository.GetCountries();
            return View(countries);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var country = new Country
                {
                    CountryId = Guid.NewGuid(),
                    Name = collection["Name"]
                };
                _countryRepository.AddCountry(country);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var country = _countryRepository.GetCountryById(id);
            return View(country);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var country = new Country
                {
                    CountryId = id,
                    Name = collection["Name"]
                };
                _countryRepository.UpdateCountry(country);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var country = _countryRepository.GetCountryById(id);
            return View(country);
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _countryRepository.DeleteCountry(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
