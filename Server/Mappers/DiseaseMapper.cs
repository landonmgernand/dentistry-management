using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Diseases;
using DentistryManagement.Shared.ViewModels.Teeth;

namespace DentistryManagement.Server.Mappers
{
    public class DiseaseMapper
    {
        public static DiseaseDTO CreateDiseaseVMToDTO(CreateDiseaseViewModel createDisease)
        {
            return new DiseaseDTO
            {
                Name = createDisease.Name,
                Description = createDisease.Description
            };
        }

        public static DiseaseDTO UpdateDiseaseVMToDTO(UpdateDiseaseViewModel updateDisease)
        {
            return new DiseaseDTO
            {
                Id = updateDisease.Id,
                Name = updateDisease.Name,
                Description = updateDisease.Description
            };
        }

        public static DiseaseDTO DiseaseVMtoDTO(ToothDiseaseViewModel toothDiseaseView)
        {
            return new DiseaseDTO
            {
                Id = toothDiseaseView.Id,
                Name = toothDiseaseView.Name
            };
        }

        public static DiseaseDTO DiseaseToDTO(Disease disease)
        {
            return new DiseaseDTO
            {
                Id = disease.Id,
                Name = disease.Name,
                Description = disease.Description
            };
        }

        public static Disease DTOtoDisease(DiseaseDTO diseaseDTO)
        {
            return new Disease
            {
                Name = diseaseDTO.Name,
                Description = diseaseDTO.Description
            };
        }

        public static DiseaseViewModel DTOtoDiseaseVM(DiseaseDTO diseaseDTO)
        {
            return new DiseaseViewModel
            {
                Id = diseaseDTO.Id,
                Name = diseaseDTO.Name,
                Description = diseaseDTO.Description
            };
        }
    }
}
