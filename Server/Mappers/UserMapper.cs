using DentistryManagement.Server.Models;
using DentistryManagement.Shared;

namespace DentistryManagement.Server.Mappers
{
    public class UserMapper
    {
        public static UserDTO UserToDTO(ApplicationUser applicationUser)
        {
            return new UserDTO
            {
                Email = applicationUser.Email
            };
        }
    }
}
