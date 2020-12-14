using System;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared.ViewModels.Schedule
{
    public class CreateScheduleViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "The Patient field is required")]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
