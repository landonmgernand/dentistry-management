using System;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class ScheduleDTO
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public PatientDTO PatientDTO { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
