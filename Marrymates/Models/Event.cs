using System.ComponentModel.DataAnnotations;

namespace MarryMatesDotNet.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "The ClientId field is required.")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "The VendorId field is required.")]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "The VenueId field is required.")]
        public int VenueId { get; set; }

        [Required(ErrorMessage = "The EventDate field is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "The TotalPrice field is required.")]
        [Range(0, 9999999.99, ErrorMessage = "TotalPrice must be between 0 and 9999999.99.")]
        public decimal TotalPrice { get; set; }


        public string EventName { get; set; }  // to add name of event
        public string Description { get; set; }  // to add desc


        public User Client { get; set; } // used for nav for client
        public User Vendor { get; set; } // used for nav for vendor
        public Venue Venue { get; set; } // used for nav for venue

    }
}
