using DentistryManagement.Server.DataTransferObjects;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IAllergyService
    {
        public void Create(AllergyDTO allergyDTO);
        public bool Exist(int id, int medicalChartId);
        public void Delete(int allergyId);
    }
}
