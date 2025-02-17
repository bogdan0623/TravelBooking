using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Models.DBObjects;
using TravelBooking.Repositories;

namespace TravelBooking.Controllers
{
    public class CityController : Controller
    {
        private readonly CityRepository _cityRepository;

        public CityController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // GET: CityController
        public ActionResult Index()
        {
            var cities = _cityRepository.GetCities();
            return View(cities);
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var city = new City
                {
                    CityId = Guid.NewGuid(),
                    Name = collection["Name"],
                    CountryId = Guid.Parse(collection["CountryId"])
                };
                _cityRepository.AddCity(city);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var city = _cityRepository.GetCityById(id);
            return View(city);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var city = new City
                {
                    CityId = id,
                    Name = collection["Name"],
                    CountryId = Guid.Parse(collection["CountryId"])
                };
                _cityRepository.UpdateCity(city);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var city = _cityRepository.GetCityById(id);
            return View(city);
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _cityRepository.DeleteCity(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
