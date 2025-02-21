﻿using System.ComponentModel.DataAnnotations;

namespace TravelBooking.Models.ViewModels
{
    public class DestinationViewModel
    {
        [Key]
        public Guid DestinationId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public decimal PricePernightPerPerson { get; set; }

        public IFormFile? Picture { get; set; }
    }
}
