using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Teeth;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Mappers
{
    public class ToothMapper
    {
        public static ToothDTO ToothToDTO(Tooth tooth)
        {
            return new ToothDTO
            {
                Id = tooth.Id,
                Url = tooth.Url,
                Category = tooth.Category,
                HasDiseases = tooth.ToothDiseases.Count > 0
            };
        }

        public static ToothViewModel ToothDTOtoVM(ToothDTO toothDTO)
        {
            return new ToothViewModel
            {
                Id = toothDTO.Id,
                Url = toothDTO.Url,
                HasDiseases = toothDTO.HasDiseases
            };
        }

        public static TeethCategoryDTO TeethToTeethCategoryDTO(List<ToothDTO> teethDTO)
        {
            return new TeethCategoryDTO
            {
                UpperRight = teethDTO.Where(t => t.Category.Equals("UpperRight")).ToList(),
                UpperLeft = teethDTO.Where(t => t.Category.Equals("UpperLeft")).ToList(),
                LowerRight = teethDTO.Where(t => t.Category.Equals("LowerRight")).ToList(),
                LowerLeft = teethDTO.Where(t => t.Category.Equals("LowerLeft")).ToList(),
            };
        }

        public static TeethCategoryViewModel TeethCategoryDTOtoVM(TeethCategoryDTO teethCategoryDTO)
        {
            return new TeethCategoryViewModel
            {
                UpperRight = teethCategoryDTO.UpperRight.Select(ur => ToothDTOtoVM(ur)).ToList(),
                UpperLeft = teethCategoryDTO.UpperLeft.Select(ur => ToothDTOtoVM(ur)).ToList(),
                LowerRight = teethCategoryDTO.LowerRight.Select(ur => ToothDTOtoVM(ur)).ToList(),
                LowerLeft = teethCategoryDTO.LowerLeft.Select(ur => ToothDTOtoVM(ur)).ToList(),
            };
        }

        public static ToothDiseasesDTO CreateToothDiseasesVMToDTO(CreateToothDiseasesViewModel toothDiseases)
        {
            return new ToothDiseasesDTO
            {
                ToothId = toothDiseases.ToothId,
                Diseases = toothDiseases.ToothDiseases.Select(d => DiseaseMapper.DiseaseVMtoDTO(d)).ToList(),
            };
        }
    }
}
