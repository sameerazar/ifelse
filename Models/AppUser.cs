using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CustomIdentity.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(100)]
        [MaxLength (100)]
        [Required]

       // public int id { get; set; }
        public string Name { get; set; }
        /*  public string?  FirstName { get; set; }

          public string? LastName { get; set; }*/
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; } 
        public string? Address { get; set; }
    }
}
