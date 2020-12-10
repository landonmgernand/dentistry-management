using System.Collections.Generic;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class TeethCategoryDTO
    {
        public List<ToothDTO> UpperRight { get; set; }

        public List<ToothDTO> UpperLeft { get; set; }

        public List<ToothDTO> LowerRight { get; set; }

        public List<ToothDTO> LowerLeft { get; set; }

        public List<ToothDTO> All { get; set; }
    }
}
