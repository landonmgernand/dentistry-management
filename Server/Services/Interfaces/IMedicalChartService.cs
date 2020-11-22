using DentistryManagement.Server.DataTransferObjects;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IMedicalChartService
    {
        public MedicalChartDTO Get(int id);
        public void Create(int id);
        public bool Exist(int id);
        public TeethCategoryDTO GetTeeth(int id);
    }
}
