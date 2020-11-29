using System.Collections.Generic;

namespace DentistryManagement.Server.Models
{
    public class MedicalChart
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public ICollection<Tooth> Teeth { get; set; }

        public ICollection<Allergy> Allergies { get; set; }

        public ICollection<File> Files { get; set; }

        public ICollection<TreatmentHistory> TreatmentHistories { get; set; }
    }
}
