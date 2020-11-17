using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IUserService<T>
    {
        public List<T> GetAll();
        public T Get(string id);
        public T GetByUsername(string username);
        public Task CreateUser(T item);
        public Task UpdateUser(T item);
        public Task UpdatePassword(T item);
        public Task DeleteUser(string id);
        public bool Exist(string id);
        public Task<bool> CheckPassword(string id, string password);
    }
}
