using System.Collections.Generic;

namespace DentistryManagement.Server.Services
{
    public interface IRoleService<T>
    {
        public List<T> GetAll();
        public bool Exist(string id);
    }
}
