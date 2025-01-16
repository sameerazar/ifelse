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
        [RegularExpression(@"^\d{14}$", ErrorMessage = "Mobile number must be exactly 13 digits.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Mobile number must be exactly 13 digits.")]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

       
    }
}
