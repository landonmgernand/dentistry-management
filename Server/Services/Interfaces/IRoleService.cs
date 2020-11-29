using DentistryManagement.Server.DataTransferObjects;
using System.Collections.Generic;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IRoleService
    {
        public List<RoleDTO> GetAll();
        public bool Exist(string id);
    }
}
