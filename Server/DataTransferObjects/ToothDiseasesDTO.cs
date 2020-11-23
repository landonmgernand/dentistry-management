using System.Collections.Generic;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class ToothDiseasesDTO
    {
        public int ToothId { get; set; }

        public List<DiseaseDTO> Diseases { get; set; }
    }
}
