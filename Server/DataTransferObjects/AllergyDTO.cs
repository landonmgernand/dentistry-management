using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class AllergyDTO
    {
        public int Id { get; set; }

        public int MedicalChartId { get; set; }

        public string Name { get; set; }
    }
}
