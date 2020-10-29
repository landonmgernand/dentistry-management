using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared
{
    public class UserDTO
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        public string NormilizedEmail { get; set; }
    }
}
