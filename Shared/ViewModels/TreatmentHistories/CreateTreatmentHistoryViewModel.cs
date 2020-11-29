using System;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared.ViewModels.TreatmentHistories
{
    public class CreateTreatmentHistoryViewModel
    {
        public string Comment { get; set; }

        [Required]
        public DateTime DateOfTreatment { get; set; }

        [Required]
        public int MedicalChartId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The Treatment field is required")]
        [Display(Name = "Treatment")]
        public int TreatmentId { get; set; }

        public string UserId { get; set; }
    }
}
