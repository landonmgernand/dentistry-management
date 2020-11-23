using DentistryManagement.Server.DataTransferObjects;
using System.Collections.Generic;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IDentistService
    {
        public List<DentistDTO> GetAll();
        public DentistDTO Get(string id);
        public DentistDTO GetByUsername(string username);
        public void Create(DentistDTO dentistDTO);
        public void Update(DentistDTO dentistDTO);
        public void Delete(string id);
        public bool Exist(string id);
    }
}
