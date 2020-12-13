using System.Collections.Generic;

namespace DentistryManagement.Shared.ViewModels.TreatmentHistories
{
    public class MonthlyTreatmentHistoryViewModel
    {
        public List<TreatmentHistoryChartViewModel> TreatmentHistories { get; set; }

        public int MaxCount { get; set; }
    }
}
