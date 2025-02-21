using TravelBooking.Models.DBObjects;
using TravelBooking.Models.ViewModels;
using TravelBooking.Repositories;

namespace TravelBooking.Factories
{
    public class CustomerViewModelFactory
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerViewModelFactory(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerViewModel GetNewCustomerViewModel(string email)
        {
            var customer = _customerRepository.GetCustomerByEmail(email);
            return GetNewCustomerViewModel(customer);
        }

        public CustomerViewModel GetNewCustomerViewModel(Customer customer)
        {
            return new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.FirstName + " " + customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };
        }
    }
}
