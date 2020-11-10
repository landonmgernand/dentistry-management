using DentistryManagement.Server.Data;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using DentistryManagement.Server.DataTransferObjects;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace DentistryManagement.Server.Services
{
    public class UserService : IUserService<UserDTO>
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
            var users = _context.ApplicationUsers
                .Include(ur => ur.UserRoles)
                .ThenInclude(r => r.Role)
                .Select(x => UserMapper.ApplicationUserToDTO(x))
                .ToList();
            
            return users;
        }

        public UserDTO Get(string id)
        {
            var applicationUser = _context.ApplicationUsers
             .Include(ur => ur.UserRoles)
             .ThenInclude(r => r.Role)
             .SingleOrDefault(x => x.Id.Equals(id));

            if (applicationUser == null)
            {
                return null;
            }

            return UserMapper.ApplicationUserToDTO(applicationUser);
        }

        public void Add(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetByUsername(string username)
        {
            var applicationUser = _context.ApplicationUsers
                .Include(ur => ur.UserRoles)
                .ThenInclude(r => r.Role)
                .SingleOrDefault(x => x.UserName.Equals(username));
           
            if (applicationUser == null)
            {
                return null;
            }

            return UserMapper.ApplicationUserToDTO(applicationUser);
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            var applicationUser = UserMapper.DTOtoApplicationUser(userDTO);
          
            await _userManager.CreateAsync(applicationUser, userDTO.Password);
            
            var roleName = "User";

            if (userDTO.IsAdmin)
            {
                roleName = "Admin";
            }

            var role = _context.ApplicationRole.SingleOrDefault(x => x.Name.Equals(roleName));

            applicationUser.UserRoles.Add(new ApplicationUserRole()
            {
                User = applicationUser,
                Role = role,
            });

            _context.SaveChanges();
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var applicationUser = _context.ApplicationUsers
                .Include(ur => ur.UserRoles)
                .SingleOrDefault(x => x.Id.Equals(userDTO.Id));

            var roleName = "User";

            if (userDTO.IsAdmin)
            {
                roleName = "Admin";
            }

            applicationUser.UserRoles.Clear();

            var role = _context.ApplicationRole.SingleOrDefault(x => x.Name.Equals(roleName));

            applicationUser.UserRoles.Add(new ApplicationUserRole()
            {
                User = applicationUser,
                Role = role,
            });

            applicationUser.FirstName = userDTO.FirstName;
            applicationUser.LastName = userDTO.LastName;
            applicationUser.PhoneNumber = userDTO.PhoneNumber;

           await _context.SaveChangesAsync();
        }

        public async Task UpdatePassword(UserDTO userDTO)
        {
            var applicationUser = await _userManager.FindByIdAsync(userDTO.Id);
            await _userManager.ChangePasswordAsync(applicationUser, userDTO.Password, userDTO.NewPassword);
        }

        public async Task DeleteUser(string id)
        {
            var applicationUser = _context.ApplicationUsers.Find(id);
            await _userManager.DeleteAsync(applicationUser);
        }

        public bool Exist(string id)
        {
            return _context.ApplicationUsers.Any(x => x.Id.Equals(id));
        }

        public async Task<bool> CheckPassword(string id, string password)
        {
            var applicationUser =  await _userManager.FindByIdAsync(id);
            return await _userManager.CheckPasswordAsync(applicationUser, password);
        }
    }
}
