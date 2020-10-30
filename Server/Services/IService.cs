using System.Collections.Generic;

namespace DentistryManagement.Server.Services
{
    public interface IService<T>
    {
        public List<T> GetAll();
        public T Get(string id);
        public void Add(T item);
        public bool Exist(string id);
    }
}
