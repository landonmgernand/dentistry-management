using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared.ViewModels.Teeth
{
    public class CreateToothDiseasesViewModel
    {
        [Required]
        public int ToothId { get; set; }

        [Required]
        public List<ToothDiseaseViewModel> ToothDiseases { get; set; }
    }
}
