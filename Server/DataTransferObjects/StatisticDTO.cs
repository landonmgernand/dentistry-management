namespace DentistryManagement.Server.DataTransferObjects
{
    public class StatisticDTO
    {
        public int PatientCount { get; set; }

        public int TreatmentCount { get; set; }

        public decimal MonthlyEarnings { get; set; }

        public decimal OverallEarnings { get; set; }

        public MonthlyTreatmentHistoryDTO MonthlyTreatmentHistory { get; set; }

        public PopularTreatmentDTO PopularTreatment { get; set; }
    }
}
