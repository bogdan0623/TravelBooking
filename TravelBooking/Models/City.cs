namespace TravelBooking.Models
{
    public class City
    {
        public Guid CityId { get; set; }

        public string Name { get; set; }

        public Guid CountryId { get; set; }
    }
}
