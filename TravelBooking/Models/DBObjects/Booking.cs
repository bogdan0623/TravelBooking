namespace TravelBooking.Models.DBObjects
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DestinationId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int StatusId { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPersons { get; set; }
    }
}
