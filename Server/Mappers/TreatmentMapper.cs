using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Treatments;
using System.Globalization;
using System.Linq;

namespace DentistryManagement.Server.Mappers
{
    public class TreatmentMapper
    {
        public static TreatmentDTO CreateTreatmentVMToDTO(CreateTreatmentViewModel createTreatment)
        {
            return new TreatmentDTO
            {
                Name = createTreatment.Name,
                Price = createTreatment.Price
            };
        }

        public static TreatmentDTO UpdateTreatmentVMToDTO(UpdateTreatmentViewModel updateTreatment)
        {
            return new TreatmentDTO
            {
                Id = updateTreatment.Id,
                Name = updateTreatment.Name,
                Price = updateTreatment.Price
            };
        }

        public static TreatmentDTO TreatmentToDTO(Treatment treatment)
        {
            return new TreatmentDTO
            {
                Id = treatment.Id,
                Name = treatment.Name,
                Price = treatment.Price
            };
        }

        public static Treatment DTOtoTreatment(TreatmentDTO treatmentDTO)
        {
            return new Treatment
            {
                Name = treatmentDTO.Name,
                Price = treatmentDTO.Price
            };
        }

        public static TreatmentViewModel DTOtoTreatmentVM(TreatmentDTO treatmentDTO)
        {
            return new TreatmentViewModel
            {
                Id = treatmentDTO.Id,
                Name = treatmentDTO.Name,
                Price = treatmentDTO.Price.ToString("c", new CultureInfo("fr-FR"))
            };
        }

        public static TreatmentChartViewModel DTOtoTreatmentChartVM(TreatmentChartDTO treatmentChartDTO)
        {
            return new TreatmentChartViewModel
            {
                Name = treatmentChartDTO.Name,
                Count = treatmentChartDTO.Count
            };
        }

        public static PopularTreatmentViewModel DTOtoPopularTreatmentVM(PopularTreatmentDTO popularTreatmentDTO)
        {
            return new PopularTreatmentViewModel
            {
                Treatments = popularTreatmentDTO.Treatments
                .Select(th => DTOtoTreatmentChartVM(th)).ToList()
            };
        }
    }
}
