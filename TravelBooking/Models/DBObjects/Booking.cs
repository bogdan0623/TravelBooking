using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TravelBooking.Models.DBObjects
{
    public class Booking
    {
        public Guid BookingId { get; set; }

        public Guid CustomerId { get; set; }

        public Guid DestinationId { get; set; }

        [Required]
        [Remote(action: "ValidateDates", controller: "Booking", AdditionalFields = nameof(CheckOut))]
        public DateTime CheckIn { get; set; }

        [Required]
        [Remote(action: "ValidateDates", controller: "Booking", AdditionalFields = nameof(CheckIn))]
        public DateTime CheckOut { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StatusId { get; set; }

        public decimal Price { get; set; }

        [Required]
        public int NumberOfPersons { get; set; }
    }
}
