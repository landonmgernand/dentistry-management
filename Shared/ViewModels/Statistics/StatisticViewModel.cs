using DentistryManagement.Shared.ViewModels.TreatmentHistories;
using DentistryManagement.Shared.ViewModels.Treatments;
using System.Collections.Generic;

namespace DentistryManagement.Shared.ViewModels.Statistics
{
    public class StatisticViewModel
    {
        public int PatientCount { get; set; }

        public int TreatmentCount { get; set; }

        public string MonthlyEarnings { get; set; }

        public string OverallEarnings { get; set; }

        public MonthlyTreatmentHistoryViewModel MonthlyTreatmentHistory { get; set; }

        public PopularTreatmentViewModel PopularTreatment { get; set; }
    }
}
