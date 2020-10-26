using DentistryManagement.Server.Models;
using DentistryManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
