using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Shared.ViewModels.Statistics;
using System.Globalization;

namespace DentistryManagement.Server.Mappers
{
    public class StatisticMapper
    {
        public static StatisticDTO ToDTO(
            int patientCount,
            int treatmentCount,
            decimal monthlyEarnings,
            decimal overallEarnings,
            MonthlyTreatmentHistoryDTO monthlyTreatmentHistoryDTO,
            PopularTreatmentDTO popularTreatmentDTO
            )
        {
            return new StatisticDTO
            {
                PatientCount = patientCount,
                TreatmentCount = treatmentCount,
                MonthlyEarnings = monthlyEarnings,
                OverallEarnings = overallEarnings,
                MonthlyTreatmentHistory = monthlyTreatmentHistoryDTO,
                PopularTreatment = popularTreatmentDTO
            };
        }

        public static StatisticViewModel DTOtoVM(StatisticDTO statisticDTO)
        {
            return new StatisticViewModel
            {
                PatientCount = statisticDTO.PatientCount,
                TreatmentCount = statisticDTO.TreatmentCount,
                MonthlyEarnings = statisticDTO.MonthlyEarnings.ToString("c", new CultureInfo("fr-FR")),
                OverallEarnings = statisticDTO.OverallEarnings.ToString("c", new CultureInfo("fr-FR")),
                MonthlyTreatmentHistory = TreatmentHistoryMapper.DTOtoMonthlyTreatmentHistoryVM(statisticDTO.MonthlyTreatmentHistory),
                PopularTreatment = TreatmentMapper.DTOtoPopularTreatmentVM(statisticDTO.PopularTreatment)
            };
        }
    }
}
