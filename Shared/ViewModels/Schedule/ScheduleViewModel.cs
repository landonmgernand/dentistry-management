using System;

namespace DentistryManagement.Shared.ViewModels.Schedule
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual string ElementType { get; set; }
    }
}
