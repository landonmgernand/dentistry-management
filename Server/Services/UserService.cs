using DentistryManagement.Server.Data;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Shared;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class UserService : IService<UserDTO>
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserDTO> GetAll()
        {
            return _context.ApplicationUsers.Select(x => UserMapper.UserToDTO(x)).ToList();
        }
    }
}
