namespace TravelBooking.Models.DBObjects
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }
    }
}
