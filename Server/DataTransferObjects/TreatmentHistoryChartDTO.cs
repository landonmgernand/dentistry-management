using System;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class TreatmentHistoryChartDTO
    {
        public DateTime DateOfTreatment { get; set; }

        public int Count { get; set; }
    }
}
