using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Shared.ViewModels.Statistics;
using System.Globalization;

namespace DentistryManagement.Server.Mappers
{
    public class StatisticMapper
    {
        public static StatisticDTO ToDTO(
            int affiliateId,
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
                AffiliateId = affiliateId,
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
                AffiliateId = statisticDTO.AffiliateId,
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
