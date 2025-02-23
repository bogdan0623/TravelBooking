using System.ComponentModel.DataAnnotations;

namespace TravelBooking.Models.ViewModels
{
    public class DestinationViewModel
    {
        [Key]
        public Guid DestinationId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string PricePernightPerPerson { get; set; }

        public string PicturePath { get; set; }
    }
}
