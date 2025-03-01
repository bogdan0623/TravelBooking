namespace TravelBooking.Models.ViewModels
{
    public class BookingViewModel
    {
        public Guid BookingId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public DestinationViewModel Destination { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPersons { get; set; }
    }
}
