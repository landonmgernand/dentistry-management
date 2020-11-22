using System.Collections.Generic;
using System.Threading.Tasks;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DentistryManagement.Server.Helpers;
using DentistryManagement.Shared.ViewModels.Users;
using DentistryManagement.Server.Mappers;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using DentistryManagement.Server.DataTransferObjects;

namespace DentistryManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<UserDTO> _userService;
        private readonly IRoleService<RoleDTO> _roleService;
        private readonly IAffiliateService<AffiliateDTO, AddressDTO> _affiliateService;

        public UserController(
            IUserService<UserDTO> userService,
            IRoleService<RoleDTO> roleService,
            IAffiliateService<AffiliateDTO, AddressDTO> affiliateService
            )
        {
            _userService = userService;
            _roleService = roleService;
            _affiliateService = affiliateService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<IEnumerable<UserViewModel>> GetUsers()
        {
            return _userService.GetAll().Select(x => UserMapper.DTOtoUserViewModel(x)).ToArray();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public ActionResult<UserViewModel> GetUser(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return UserMapper.DTOtoUserViewModel(user);
        }

        [HttpGet("email/{email}")]
        public ActionResult<UserViewModel> GetUserByEmail(string email)
        {
            var user = _userService.GetByUsername(email);

            if (user == null)
            {
                return NotFound();
            }
           
            return UserMapper.DTOtoUserViewModel(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserViewModel createUserViewModel)
        {
            if (!_roleService.Exist(createUserViewModel.RoleId) || !_affiliateService.Exist(createUserViewModel.AffiliateId))
            {
                return NotFound();
            }

            if (_userService.GetByUsername(createUserViewModel.Email) != null)
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

            await _userService.CreateUser(userDTO);

            return Ok(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserViewModel updateUserViewModel)
        {
            if (id != updateUserViewModel.Id)
            {
                return BadRequest();
            }

            if (
                !_userService.Exist(id) || 
                !_roleService.Exist(updateUserViewModel.RoleId) ||
                !_affiliateService.Exist(updateUserViewModel.AffiliateId)
                )
            {
                return NotFound();
            }

            var userDTO = UserMapper.UpdateUserViewModelToDTO(updateUserViewModel);

            await _userService.UpdateUser(userDTO);

            return NoContent();
        }

        [HttpPut("password/{id}")]
        public async Task<IActionResult> UpdatePassword(string id, PasswordUserViewModel passwordUserViewModel)
        {
            if (!_userService.Exist(id))
            {
                return NotFound();
            }

            if (!await _userService.CheckPassword(passwordUserViewModel.Id, passwordUserViewModel.CurrentPassword))
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

            await _userService.UpdatePassword(userDTO);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (!_userService.Exist(id))
            {
                return NotFound();
            }

            await _userService.DeleteUser(id);

            return NoContent();
        }
    }
}
