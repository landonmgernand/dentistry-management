using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Services
{
    public interface IUserService<T>
    {
        public List<T> GetAll();
        public T Get(string id);
        public ActionResult<T> GetByUsername(string username);
        public Task<T> CreateUser(T item);
        public Task UpdateUser(T item);
        public Task DeleteUser(string id);
        public bool Exist(string id);
    }
}
