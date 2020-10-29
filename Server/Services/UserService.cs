using DentistryManagement.Server.Data;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Services
{
    public class UserService : IService<UserDTO>
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<UserDTO> GetAll()
        {
            return _context.ApplicationUsers.Select(x => UserMapper.ApplicationUserToDTO(x)).ToList();
        }

        public UserDTO Get(string id)
        {
            var user = _context.ApplicationUsers.Find(id);
            return UserMapper.ApplicationUserToDTO(user);
        }

        public void Add(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public ActionResult<UserDTO> GetByUsername(string username)
        {
            var user = _context.ApplicationUsers.SingleOrDefault(x => x.UserName.Equals(username));

            if (user == null)
            {
                return null;
            }

            return UserMapper.ApplicationUserToDTO(user);
        }

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            var applicationUser = UserMapper.DTOtoApplicationUser(userDTO);
            await _userManager.CreateAsync(applicationUser, userDTO.PasswordHash);

            return UserMapper.ApplicationUserToDTO(applicationUser);
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var applicationUser = await _userManager.FindByIdAsync(userDTO.Id);
            applicationUser.FirstName = userDTO.FirstName;
            applicationUser.LastName = userDTO.LastName;
            await _userManager.UpdateAsync(applicationUser);
        }

        public async Task RemoveUser(string id)
        {
            var applicationUser = _context.ApplicationUsers.Find(id);
            await _userManager.DeleteAsync(applicationUser);
        }
    }
}
