namespace TravelBooking.Models.DBObjects
{
    public class Image
    {
        public Guid ImageId { get; set; }
        public string Name { get; set; }
        public Guid DestinationId { get; set; }
    }
}
