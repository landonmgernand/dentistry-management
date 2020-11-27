using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Files;

namespace DentistryManagement.Server.Mappers
{
    public class FileMapper
    {
        public static FileDTO FileToFileDTO(File file)
        {
            return new FileDTO
            {
                Id = file.Id,
                Path = file.Path,
                UploadDT = file.UploadDT
            };
        }


        public static FileViewModel DTOtoFiileVM(FileDTO fileDTO)
        {
            return new FileViewModel
            {
                Id = fileDTO.Id,
                Path = fileDTO.Path,
                UploadDT = fileDTO.UploadDT
            };
        }
    }
}
