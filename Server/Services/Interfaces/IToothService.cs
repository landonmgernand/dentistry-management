using DentistryManagement.Server.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IToothService
    {
        public List<DiseaseDTO> GetDiseases(int id);
        public List<CommentDTO> GetComments(int id);
        public bool Exist(int id);
        public void CreateToothDiseases(ToothDiseasesDTO toothDiseases);
    }
}
