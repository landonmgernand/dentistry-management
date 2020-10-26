using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentistryManagement.Server.Models;
using DentistryManagement.Server.Services;
using DentistryManagement.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
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
