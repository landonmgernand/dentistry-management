using System.Collections.Generic;
using DentistryManagement.Server.Services;
using DentistryManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            return _service.GetAll();
        }
    }
}
