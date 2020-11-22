using System.Collections.Generic;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IDentistService<T>
    {
        public List<T> GetAll();
        public T Get(string id);
        public T GetByUsername(string username);
        public void Create(T item);
        public void Update(T item);
        public void Delete(string id);
        public bool Exist(string id);
    }
}
