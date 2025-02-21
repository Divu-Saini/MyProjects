using System.ComponentModel.DataAnnotations;

namespace MarryMatesDotNet.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "The name field must contain only letters and spaces.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The passwordHash field is required.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "The role field is required.")]
        [RegularExpression("Admin|Client|Vendor", ErrorMessage = "Role must be Admin, Client, or Vendor.")]
        public string Role { get; set; }
    }
}
