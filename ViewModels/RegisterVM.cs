using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [DataType (DataType.EmailAddress)]
        [Required]
        public string?  Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "Mobile number must be 13  digits.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Mobile number must be exactly 13 digits.")]
        public string? PhoneNumber { get; set; } 

        [Required ]
        [DataType (DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$", ErrorMessage = "The password must contain  " +
            "(Minimum 8 and Maximum 16 characters , 1 Number and 1 Special Character.")]
        public  string? Password { get; set; }
        [Compare("Password",ErrorMessage = "Password doesn't match")]
        public  string? ConfirmPassword { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

    }
}
