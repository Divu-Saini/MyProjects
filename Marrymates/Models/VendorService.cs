using System.ComponentModel.DataAnnotations;

namespace MarryMatesDotNet.Models
{
    public class VendorService
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "The VendorId field is required.")]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "The ServiceName field is required.")]
        [StringLength(100, ErrorMessage = "ServiceName cannot exceed 100 characters.")]
        public string ServiceName { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0, 9999999.99, ErrorMessage = "Price must be between 0 and 9999999.99.")]
        public decimal Price { get; set; }

       // public User Vendor { get; set; } 
    }

}
