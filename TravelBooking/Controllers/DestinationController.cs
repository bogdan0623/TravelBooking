﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Factories;
using TravelBooking.Repositories;

namespace TravelBooking.Controllers
{
    public class DestinationController : Controller
    {   
        private readonly DestinationRepository _destinationRepository;
        private readonly DestinationViewModelFactory _destinationViewModelFactory;

        public DestinationController(DestinationRepository destinationRepository, DestinationViewModelFactory destinationViewModelFactory)
        {
            _destinationRepository = destinationRepository;
            _destinationViewModelFactory = destinationViewModelFactory;
        }

        // GET: DestinationController
        public ActionResult Index()
        {
            var destinations = _destinationRepository.GetDestinations().Select(
                _destinationViewModelFactory.GetNewDestinationViewModel).ToList();
            return View(destinations);
        }

        // GET: DestinationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DestinationController/Create
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
