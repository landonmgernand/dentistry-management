using System.Collections.Generic;

namespace DentistryManagement.Server.Models
{
    public class MedicalChart
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public ICollection<Tooth> Teeth { get; set; }
    }
}
