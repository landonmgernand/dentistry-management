using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared.ViewModels.MedicalChart
{
    public class OpenMedicalChartViewModel
    {
        [Required]
        public int PatientId { get; set; }
    }
}
