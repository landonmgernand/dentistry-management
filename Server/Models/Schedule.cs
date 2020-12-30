using System;

namespace DentistryManagement.Server.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
