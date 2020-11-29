using DentistryManagement.Server.DataTransferObjects;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface ITreatmentHistoryService
    {
        public TreatmentHistoryDTO Get(int medicalChartId, int treatmentHistoryId);
        public void Create(TreatmentHistoryDTO treatmentHistoryDTO);
        public void Update(TreatmentHistoryDTO treatmentHistoryDTO);
        public void Delete(int treatmentHistoryId);
        public bool Exist(int medicalChartId, int treatmentHistoryId);
    }
}
