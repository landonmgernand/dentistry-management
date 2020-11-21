using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Models
{
    public class ToothDisease
    {
        public int DiseaseId { get; set; }

        public Disease Disease { get; set; }

        public int ToothId { get; set; }

        public Tooth Tooth { get; set; }
    }
}
