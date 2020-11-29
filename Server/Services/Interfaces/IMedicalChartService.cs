using DentistryManagement.Server.DataTransferObjects;
using System.Collections.Generic;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IMedicalChartService
    {
        public MedicalChartDTO Get(int id);
        public void Create(int id);
        public bool Exist(int id);
        public TeethCategoryDTO GetTeeth(int medicalChartId);
        public List<AllergyDTO> GetAllergies(int medicalChartId); 
        public List<FileDTO> GetFiles(int medicalChartId);
        public List<TreatmentHistoryDTO> GetTreatmentHistories(int medicalChartId);
    }
}
