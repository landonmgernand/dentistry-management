using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
    }
}
