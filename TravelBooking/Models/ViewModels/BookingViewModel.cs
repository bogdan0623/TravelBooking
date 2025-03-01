using System.ComponentModel.DataAnnotations;

namespace TravelBooking.Models.ViewModels
{
    public class BookingViewModel
    {
        [Key]
        public Guid BookingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string DestinationName { get; set; }
        public string DestinationLocation { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPersons { get; set; }
    }
}
