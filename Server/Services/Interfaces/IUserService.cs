using DentistryManagement.Server.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IUserService
    {
        public List<UserDTO> GetAll();
        public List<UserDTO> GetAffiliateUsers(int affiliateId);
        public UserDTO Get(string id);
        public UserDTO GetByUsername(string username);
        public UserDTO GetCurrent();
        public Task CreateUser(UserDTO userDTO);
        public Task UpdateUser(UserDTO userDTO);
        public Task UpdatePassword(UserDTO userDTO);
        public Task DeleteUser(string id);
        public bool Exist(string id);
        public Task<bool> CheckPassword(string id, string password);
    }
}
