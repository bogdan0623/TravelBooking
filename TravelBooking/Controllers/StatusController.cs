using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Models.DBObjects;
using TravelBooking.Repositories;

namespace TravelBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatusController : Controller
    {
        private readonly StatusRepository _statusRepository;

        public StatusController(StatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        // GET: StatusController
        public ActionResult Index()
        {
            var statuses = _statusRepository.GetStatuses();
            return View(statuses);
        }

        // GET: StatusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Status status = new Status
                {
                    StatusId = int.Parse(collection["StatusId"]),
                    Value = collection["Value"]
                };
                _statusRepository.AddStatus(status);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatusController/Edit/5
        public ActionResult Edit(int id)
        {
            var status = _statusRepository.GetStatusById(id);
            return View(status);
        }

        // POST: StatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var status = new Status
                {
                    StatusId = id,
                    Value = collection["Value"]
                };
                _statusRepository.UpdateStatus(status);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatusController/Delete/5
        public ActionResult Delete(int id)
        {
            var status = _statusRepository.GetStatusById(id);
            return View(status);
        }

        // POST: StatusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _statusRepository.DeleteStatus(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
