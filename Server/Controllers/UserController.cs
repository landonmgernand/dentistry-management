using System.Collections.Generic;
using System.Threading.Tasks;
using DentistryManagement.Server.Models;
using DentistryManagement.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DentistryManagement.Server.Helpers;
using DentistryManagement.Shared.ViewModels;
using DentistryManagement.Server.Mappers;
using System.Linq;

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

        [HttpGet]
        public ActionResult<IEnumerable<UserViewModel>> GetUsers()
        {
            return _service.GetAll().Select(x => UserMapper.DTOtoUserViewModel(x)).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<UserViewModel> GetUser(string id)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return UserMapper.DTOtoUserViewModel(user);
        }

        [HttpGet("email/{email}")]
        public ActionResult<UserViewModel> GetUserByEmail(string email)
        {
            var user = _service.GetByUsername(email);

            if (user == null)
            {
                return NotFound();
            }

            return UserMapper.DTOtoUserViewModel(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserViewModel createUserViewModel)
        {
            if (_service.GetByUsername(createUserViewModel.Email) != null)
            {
                ModelState.AddModelError(nameof(createUserViewModel.Email), "This email is already taken");
                return BadRequest(ModelState);
            }

            if (!PasswordChecker.ValidatePassword(createUserViewModel.Password, out var message))
            {
                ModelState.AddModelError(nameof(createUserViewModel.Password), message);
                return BadRequest(ModelState);
            }

            var userDTO = UserMapper.AddUserViewModelToDTO(createUserViewModel);

            await _service.CreateUser(userDTO);

            return Ok(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserViewModel updateUserViewModel)
        {
            if (id != updateUserViewModel.Id)
            {
                return BadRequest();
            }

            if (!_service.Exist(id))
            {
                return NotFound();
            }

            var userDTO = UserMapper.UpdateUserViewModelToDTO(updateUserViewModel);

            await _service.UpdateUser(userDTO);

            return NoContent();
        }

        [HttpPut("password/{id}")]
        public async Task<IActionResult> UpdatePassword(string id, PasswordUserViewModel passwordUserViewModel)
        {
            if (!_service.Exist(id))
            {
                return NotFound();
            }

            if (!await _service.CheckPassword(passwordUserViewModel.Id, passwordUserViewModel.CurrentPassword))
            {
                ModelState.AddModelError(nameof(passwordUserViewModel.CurrentPassword), "The password you provided is wrong");
                return BadRequest(ModelState);
            }

            if (!PasswordChecker.ValidatePassword(passwordUserViewModel.NewPassword, out var message))
            {
                ModelState.AddModelError(nameof(passwordUserViewModel.NewPassword), message);
                return BadRequest(ModelState);
            }

            var userDTO = UserMapper.PasswordUserViewModelToDTO(passwordUserViewModel);

            await _service.UpdatePassword(userDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (!_service.Exist(id))
            {
                return NotFound();
            }

            await _service.DeleteUser(id);

            return NoContent();
        }
    }
}
