using DentistryManagement.Server.Models;
using DentistryManagement.Shared;

namespace DentistryManagement.Server.Mappers
{
    public class UserMapper
    {
        public static UserDTO ApplicationUserToDTO(ApplicationUser applicationUser)
        {
            return new UserDTO
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                NormilizedEmail = applicationUser.NormalizedEmail
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
    }
}
