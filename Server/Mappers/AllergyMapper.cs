using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Allergies;

namespace DentistryManagement.Server.Mappers
{
    public class AllergyMapper
    {
        public static AllergyDTO CreateAllergyVMToDTO(CreateAllergyViewModel createAllergy)
        {
            return new AllergyDTO
            {
                MedicalChartId = createAllergy.MedicalChartId,
                Name = createAllergy.Name,
            };
        }

        public static AllergyViewModel DTOtoAllergyVM(AllergyDTO allergyDTO)
        {
            return new AllergyViewModel
            {
                Id = allergyDTO.Id,
                Name = allergyDTO.Name
            };
        }

        public static AllergyDTO AllergyToDTO(Allergy allergy)
        {
            return new AllergyDTO
            {
                Id = allergy.Id,
                Name = allergy.Name
            };
        }

        public static Allergy DTOtoAllergy(AllergyDTO allergyDTO)
        {
            return new Allergy
            {
                Name = allergyDTO.Name
            };
        }
    }
}
