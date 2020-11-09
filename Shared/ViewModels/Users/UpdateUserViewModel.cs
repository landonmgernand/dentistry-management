using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared.ViewModels.Users
{
    public class UpdateUserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter a valid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }
    }
}
