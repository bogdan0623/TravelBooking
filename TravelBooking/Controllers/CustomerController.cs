using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBooking.Factories;
using TravelBooking.Models.DBObjects;
using TravelBooking.Models.ViewModels;
using TravelBooking.Repositories;

namespace TravelBooking.Controllers
{    
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly CustomerViewModelFactory _customerViewModelFactory;

        public CustomerController(CustomerRepository customerRepository, CustomerViewModelFactory customerViewModelFactory)
        {
            _customerRepository = customerRepository;
            _customerViewModelFactory = customerViewModelFactory;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var customers = _customerRepository.GetCustomers().Select(
                _customerViewModelFactory.GetNewCustomerViewModel).ToList();
            return View(customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var customer = new Customer
                {
                    CustomerId = Guid.NewGuid(),
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Email = collection["Email"],
                    Phone = collection["Phone"]
                };
                _customerRepository.AddCustomer(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            var customerViewModel = _customerViewModelFactory.GetNewCustomerViewModel(customer);
            return View(customerViewModel);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _customerRepository.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
