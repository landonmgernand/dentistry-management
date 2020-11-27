using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IFileService
    {
        public Task Create(int medicalChartId, IFormFile file);
        public bool Exist(int id, int medicalChartId);
        public void Delete(int fileId);
    }
}
