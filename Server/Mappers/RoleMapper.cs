using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Roles;

namespace DentistryManagement.Server.Mappers
{
    public class RoleMapper
    {
        public static RoleDTO RoleToDTO(ApplicationRole applicationRole)
        {
            return new RoleDTO
            {
                Id = applicationRole.Id,
                Name = applicationRole.Name
            };
        }

        public static RoleViewModel DTOtoRoleVM(RoleDTO roleDTO)
        {
            return new RoleViewModel
            {
                Id = roleDTO.Id,
                Name = roleDTO.Name,
            };
        }

        public static RoleDTO UserRoleToDTO(ApplicationUserRole applicationUserRole)
        {
            return new RoleDTO
            {
                Id = applicationUserRole.RoleId,
                Name = applicationUserRole.Role.Name
            };
        }
    }
}
