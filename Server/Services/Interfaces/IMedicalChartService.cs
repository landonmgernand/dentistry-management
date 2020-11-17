namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IMedicalChartService<T>
    {
        public T Get(int id);
        public void Create(int patientId);
        public bool Exist(int id);      
    }
}
