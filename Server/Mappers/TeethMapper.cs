using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Teeth;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Mappers
{
    public class TeethMapper
    {
        public static ToothDTO TeethToDTO(Teeth teeth)
        {
            return new ToothDTO
            {
                Id = teeth.Id,
                Url = teeth.Url,
                Category = teeth.Category
            };
        }

        public static ToothViewModel ToothDTOtoVM(ToothDTO toothDTO)
        {
            return new ToothViewModel
            {
                Id = toothDTO.Id,
                Url = toothDTO.Url
            };
        }

        public static TeethCategoryDTO TeethToTeethCategoryDTO(List<ToothDTO> toothDTOs)
        {
            return new TeethCategoryDTO
            {
                UpperRight = toothDTOs.Where(t => t.Category.Equals("UpperRight")).ToList(),
                UpperLeft = toothDTOs.Where(t => t.Category.Equals("UpperLeft")).ToList(),
                LowerRight = toothDTOs.Where(t => t.Category.Equals("LowerRight")).ToList(),
                LowerLeft = toothDTOs.Where(t => t.Category.Equals("LowerLeft")).ToList(),
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
    }
}
