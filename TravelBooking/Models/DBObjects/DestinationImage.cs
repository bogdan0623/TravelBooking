namespace TravelBooking.Models.DBObjects
{
    public class DestinationImage
    {
        public Guid DestinationImageId { get; set; }
        public Guid DestinationId { get; set; }
        public Guid ImageId { get; set; }
    }
}
