using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Users;
using System.Linq;
using System.Collections.Generic;

namespace DentistryManagement.Server.Mappers
{
    public class UserMapper
    {
        public static UserDTO AddUserViewModelToDTO(CreateUserViewModel addUserViewModel)
        {
            return new UserDTO
            {
                Email = addUserViewModel.Email,
                FirstName = addUserViewModel.FirstName,
                LastName = addUserViewModel.LastName,
                Password = addUserViewModel.Password,
                PhoneNumber = addUserViewModel.PhoneNumber,
                AffiliateId = addUserViewModel.AffiliateId,
                RoleId = addUserViewModel.RoleId
            };
        }

        public static UserDTO UpdateUserViewModelToDTO(UpdateUserViewModel updateUserViewModel)
        {
            return new UserDTO
            {
                Id = updateUserViewModel.Id,
                FirstName = updateUserViewModel.FirstName,
                LastName = updateUserViewModel.LastName,
                PhoneNumber = updateUserViewModel.PhoneNumber,
                AffiliateId = updateUserViewModel.AffiliateId,
                RoleId = updateUserViewModel.RoleId
            };
        }

        public static UserDTO PasswordUserViewModelToDTO(PasswordUserViewModel passwordUserViewModel)
        {
            return new UserDTO
            {
                Id = passwordUserViewModel.Id,
                Password = passwordUserViewModel.CurrentPassword,
                NewPassword = passwordUserViewModel.NewPassword
            };
        }

        public static UserDTO ApplicationUserToDTO(ApplicationUser applicationUser)
        {

            return new UserDTO
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                PhoneNumber = applicationUser.PhoneNumber,
                AffiliateDTO = applicationUser.Affiliate is null ? null : AffiliateMapper.AffiliateToDTO(applicationUser.Affiliate),
                RoleDTO = applicationUser.UserRoles.Count == 0 ? null : RoleMapper.UserRoleToDTO(applicationUser.UserRoles.First())
            };
        }

        public static ApplicationUser DTOtoApplicationUser(UserDTO userDTO)
        {
            return new ApplicationUser
            {
                Email = userDTO.Email,
                UserName = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                PhoneNumber = userDTO.PhoneNumber,
                EmailConfirmed = true,
                UserRoles = new List<ApplicationUserRole>(),
            };
        }

        public static UserViewModel DTOtoUserViewModel(UserDTO userDTO)
        {
            return new UserViewModel
            {
                Id = userDTO.Id,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
                AffiliateId = userDTO.AffiliateDTO is null ? 0 : userDTO.AffiliateDTO.Id,
                Affiliate = userDTO.AffiliateDTO?.Name,
                RoleId = userDTO.RoleDTO?.Id,
                Role = userDTO.RoleDTO?.Name
            };
        }
    }
}
