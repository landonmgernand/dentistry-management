using System.Collections.Generic;

namespace DentistryManagement.Server.Services
{
    public interface IService<T>
    {
        public List<T> GetAll();
    }
}
