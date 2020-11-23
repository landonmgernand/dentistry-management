using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exist(string id)
        {
            return _context.ApplicationRole.Any(x => x.Id.Equals(id));
        }

        public List<RoleDTO> GetAll()
        {
            var roles = _context.ApplicationRole
                .Select(r => RoleMapper.RoleToDTO(r))
                .ToList();

            return roles;
        }
    }
}
