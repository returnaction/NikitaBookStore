using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NikitaBookStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;

        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }


    }
}
