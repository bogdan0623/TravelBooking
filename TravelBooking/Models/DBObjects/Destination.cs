namespace TravelBooking.Models.DBObjects
{
    public class Destination
    {
        public Guid DestinationId { get; set; }

        public string Name { get; set; }

        public Guid CityId { get; set; }

        public string Description { get; set; }

        public decimal PricePernightPerPerson { get; set; }

        public string Picture { get; set; }
    }
}
