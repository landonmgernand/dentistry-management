using System.Collections.Generic;
using System.Linq;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services;
using DentistryManagement.Shared.ViewModels.Roles;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _service;

        public RoleController(RoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleViewModel>> GetRoles()
        {
            return _service.GetAll().Select(a => RoleMapper.DTOtoRoleVM(a)).ToArray();
        }
    }
}
