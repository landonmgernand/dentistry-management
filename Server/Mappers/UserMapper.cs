using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels;

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
                Password = addUserViewModel.Password
            };
        }

        public static UserDTO UpdateUserViewModelToDTO(UpdateUserViewModel updateUserViewModel)
        {
            return new UserDTO
            {
                Id = updateUserViewModel.Id,
                FirstName = updateUserViewModel.FirstName,
                LastName = updateUserViewModel.LastName,
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
                EmailConfirmed = true
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
            };
        }
    }
}
