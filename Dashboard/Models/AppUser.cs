using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel;

namespace Dashboard.Models
{
    
    public class AppUser:IdentityUser
    {

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        [DisplayName("Last Seen")]
        public DateTime LastSeen { get; set; }

    }
}
