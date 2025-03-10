﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TravelBooking.Models.ViewModels
{
    public class BookingViewModel
    {
        [Key]
        public Guid BookingId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        public string DestinationName { get; set; }

        public string DestinationLocation { get; set; }

        [Required]
        [Remote(action: "ValidateDates", controller: "Booking", AdditionalFields = nameof(CheckIn))]
        public DateTime CheckIn { get; set; }

        [Required]
        [Remote(action: "ValidateDates", controller: "Booking", AdditionalFields = nameof(CheckOut))]
        public DateTime CheckOut { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public string Status { get; set; }

        public string Price { get; set; }

        [Required]
        public int NumberOfPersons { get; set; }

    }
}