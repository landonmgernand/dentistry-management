using System.Collections.Generic;
using System.Threading.Tasks;
using DentistryManagement.Server.Models;
using DentistryManagement.Server.Services;
using DentistryManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DentistryManagement.Server.Helpers;

namespace DentistryManagement.Server.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUser(string id)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            if (_service.GetByUsername(userDTO.Email) != null)
            {
                ModelState.AddModelError("Username", "This username is already taken");
                return ValidationProblem();
            }

            if (!PasswordChecker.ValidatePassword(userDTO.PasswordHash, out var message))
            {
                ModelState.AddModelError("Password", message);
                return ValidationProblem();
            }

            var returnedUserDTO = await _service.AddUser(userDTO);

            return CreatedAtAction(nameof(GetUser), new { id = returnedUserDTO.Id }, returnedUserDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }

            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            await _service.UpdateUser(userDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(string id)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            await _service.RemoveUser(id);

            return NoContent();
        }
    }
}
