using System.Collections.Generic;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class MonthlyTreatmentHistoryDTO
    {
        public List<TreatmentHistoryChartDTO> TreatmentHistories { get; set; }

        public int MaxCount { get; set; }
    }
}
