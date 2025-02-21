using System.ComponentModel.DataAnnotations;

namespace MarryMatesDotNet.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        [Required(ErrorMessage = "The VenueName field is required.")]
        [StringLength(100, ErrorMessage = "VenueName cannot exceed 100 characters.")]
        public string VenueName { get; set; }

        [Required(ErrorMessage = "The Location field is required.")]
        [StringLength(255, ErrorMessage = "Location cannot exceed 255 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "The Capacity field is required.")]
        [Range(1, 100000, ErrorMessage = "Capacity must be at least 1.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0, 9999999.99, ErrorMessage = "Price must be between 0 and 9999999.99.")]
        public decimal Price { get; set; }
    }
}
