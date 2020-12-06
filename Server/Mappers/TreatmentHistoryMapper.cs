using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.TreatmentHistories;

namespace DentistryManagement.Server.Mappers
{
    public class TreatmentHistoryMapper
    {
        public static TreatmentHistoryDTO CreateTreatmentHistoryVMToDTO(CreateTreatmentHistoryViewModel createTreatmentHistory)
        {
            return new TreatmentHistoryDTO
            {
                Comment = createTreatmentHistory.Comment,
                DateOfTreatment = createTreatmentHistory.DateOfTreatment,
                MedicalChartId = createTreatmentHistory.MedicalChartId,
                TreatmentId = createTreatmentHistory.TreatmentId,
                UserId = createTreatmentHistory.UserId,
                ToothId = createTreatmentHistory.ToothId
            };
        }

        public static TreatmentHistoryDTO UpdateTreatmentHistoryVMToDTO(UpdateTreatmentHistoryViewModel updateTreatmentHistory)
        {
            return new TreatmentHistoryDTO
            {
                Id = updateTreatmentHistory.Id,
                Comment = updateTreatmentHistory.Comment,
                TreatmentId = updateTreatmentHistory.TreatmentId,
                UserId = updateTreatmentHistory.UserId,
                ToothId = updateTreatmentHistory.ToothId
            };
        }

        public static TreatmentHistoryDTO TreatmentHistoryToDTO(TreatmentHistory treatmentHistory)
        {
            return new TreatmentHistoryDTO
            {
                Id = treatmentHistory.Id,
                Comment = treatmentHistory.Comment,
                DateOfTreatment = treatmentHistory.DateOfTreatment,
                Price = treatmentHistory.Price,
                MedicalChart = treatmentHistory.MedicalChart,
                Treatment = treatmentHistory.Treatment,
                Tooth = treatmentHistory.Tooth,
                User = treatmentHistory.User,
                Affiliate = treatmentHistory.Affiliate
            };
        }

        public static TreatmentHistory DTOtoTreatmentHistory(TreatmentHistoryDTO treatmentHistoryDTO)
        {
            return new TreatmentHistory
            {
                Comment = treatmentHistoryDTO.Comment,
                DateOfTreatment = treatmentHistoryDTO.DateOfTreatment,
            };
        }

        public static TreatmentHistoryViewModel DTOtoTreatmentHistoryVM(TreatmentHistoryDTO treatmentHistoryDTO)
        {
            return new TreatmentHistoryViewModel
            {
                Id = treatmentHistoryDTO.Id,
                Comment = treatmentHistoryDTO.Comment,
                Price = treatmentHistoryDTO.Price,
                DateOfTreatment = treatmentHistoryDTO.DateOfTreatment.ToString("dd-MM-yyyy"),
                User = treatmentHistoryDTO.User.FirstName + " " + treatmentHistoryDTO.User.LastName,
                UserId = treatmentHistoryDTO.User.Id,
                Treatment = treatmentHistoryDTO.Treatment.Name,
                TreatmentId = treatmentHistoryDTO.Treatment.Id,
                Tooth = treatmentHistoryDTO.Tooth.Category + " (" + treatmentHistoryDTO.Tooth.Number + ")",
                ToothId = treatmentHistoryDTO.Tooth.Id,
                Affiliate = treatmentHistoryDTO.Affiliate.Name               
            };
        }
    }
}
