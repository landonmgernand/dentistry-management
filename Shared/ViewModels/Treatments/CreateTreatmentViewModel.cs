using System;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared.ViewModels.Treatments
{
    public class CreateTreatmentViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
