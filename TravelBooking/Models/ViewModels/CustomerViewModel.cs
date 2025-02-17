using System.ComponentModel.DataAnnotations;

namespace TravelBooking.Models.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
