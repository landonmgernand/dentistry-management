using System.Collections.Generic;
using System.Linq;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Roles;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
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
