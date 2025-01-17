using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.Models
{
    public class AppUserList
    {

        public  int id { get; set; }

        [Required]
        public  string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^\+?\d{12}$", ErrorMessage = "Mobile number must be exactly 12 digits.")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Mobile number must be exactly 12 digits.")]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

       
    }
}
