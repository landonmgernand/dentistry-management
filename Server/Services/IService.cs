using System.Collections.Generic;

namespace DentistryManagement.Server.Services
{
    public interface IService<T>
    {
        public List<T> GetAll();
        public T Get(int id);
        public void Create(T item);
        public void Update(T item);
        public void Delete(int id);
        public bool Exist(int id);
    }
}
