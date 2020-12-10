using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared.ViewModels.TreatmentHistories
{
    public class UpdateTreatmentHistoryViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Comment { get; set; }

        public int TreatmentId { get; set; }

        public int ToothId { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public string DateOfTreatment { get; set; }
    }
}
