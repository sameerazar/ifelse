using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomIdentity.Models
{
    public class Property
    {
        [Key]
        public int Property_ID { get; set; }

        [Required]
        public string Property_Name { get; set; }
        [Required]
        public string Property_Type { get; set; }
        [Required]
        public string Location { get; set; }

        [Range(0, 99999.99, ErrorMessage = "Size must be a positive value.")]
        public decimal Size_SqFt { get; set; }
        [Range(0, 999999999.99, ErrorMessage = "Price must be a positive value.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "No of Bedrooms")]
        [Range(1, 10, ErrorMessage = "Number of Bedrooms must be between 1 to 10")]
        //[RegularExpression(@"^\+?\d{2}$", ErrorMessage = "No of Bedrooms must be in 2 digits.")]
        //[StringLength(2, MinimumLength = 1, ErrorMessage = "Mobile number must be exactly 12 digits.")]
        public int Number_of_Bedrooms { get; set; }
        [Display(Name = "No of Bathrooms")]
        [Range(1, 10, ErrorMessage = "Number of Bedrooms must be between 1 to 10")]
       // [RegularExpression(@"^\+?\d{1}$", ErrorMessage = "No of Bathrooms must be in 2 digits.")]
        //[StringLength(2, MinimumLength = 1, ErrorMessage = "No of Bathrooms must be in 2 digits.")]
        public int Number_of_Bathrooms { get; set; }


       
    }
}
