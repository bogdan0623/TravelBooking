using System.ComponentModel.DataAnnotations;
using TravelBooking.Models.DBObjects;

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

        public List<string> ImagesNames { get; set; }
    }
}
