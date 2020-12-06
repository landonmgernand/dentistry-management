using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Server.Models
{
    public class Tooth
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Url { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }

        public int Number { get; set; }

        public int Order { get; set; }

        public int MedicalChartId { get; set; }

        public MedicalChart MedicalChart { get; set; }

        public ICollection<ToothDisease> ToothDiseases { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<TreatmentHistory> TreatmentHistories { get; set; }
    }
}
