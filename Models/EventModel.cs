using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class EventModel
    {
        public Guid Id { get; set; } // Change Id to GUID

        [Required(ErrorMessage = "Event name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Event date is required.")]
        [CustomValidation(typeof(EventModel), nameof(ValidateDate))]
        public DateTime? Date { get; set; } // Make Date nullable

        [Required(ErrorMessage = "Event location is required.")]
        public string? Location { get; set; }

        public List<Attendee> Attendees { get; set; } = new List<Attendee>(); // Ensure correct initialization

        public string? Description { get; set; } // Mark Description as nullable

        public static ValidationResult? ValidateDate(DateTime? date, ValidationContext context)
        {
            if (!date.HasValue)
            {
                return new ValidationResult("Event date is required.");
            }

            if (date.Value < DateTime.Now)
            {
                return new ValidationResult("Event date cannot be in the past.");
            }
            return ValidationResult.Success;
        }
    }
}
