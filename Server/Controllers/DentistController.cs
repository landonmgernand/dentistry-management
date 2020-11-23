using System.Collections.Generic;
using System.Linq;
using DentistryManagement.Server.Helpers;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Dentists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DentistController : ControllerBase
    {
        private readonly IDentistService _service;

        public DentistController(IDentistService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DentistViewModel>> GetDentists()
        {
            return _service.GetAll().Select(x => DentistMapper.DTOtoDentistViewModel(x)).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<DentistViewModel> GetDentist(string id)
        {
            var dentist = _service.Get(id);

            if (dentist == null)
            {
                return NotFound();
            }

            return DentistMapper.DTOtoDentistViewModel(dentist);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public IActionResult CreateDentist([FromBody] CreateDentistViewModel createDentistViewModel)
        {
            if (_service.GetByUsername(createDentistViewModel.Email) != null)
            {
                ModelState.AddModelError(nameof(createDentistViewModel.Email), "This email is already taken");
                return BadRequest(ModelState);
            }

            if (!PasswordChecker.ValidatePassword(createDentistViewModel.Password, out var message))
            {
                ModelState.AddModelError(nameof(createDentistViewModel.Password), message);
                return BadRequest(ModelState);
            }

            var dentalDTO = DentistMapper.AddDentistViewModelToDTO(createDentistViewModel);

            _service.Create(dentalDTO);

            return Ok(ModelState);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("{id}")]
        public IActionResult UpdateDentist(string id, [FromBody] UpdateDentistViewModel updateDentistViewModel)
        {
            if (id != updateDentistViewModel.Id)
            {
                return BadRequest();
            }

            if (!_service.Exist(id))
            {
                return NotFound();
            }

            var dentalDTO = DentistMapper.UpdateDentistViewModelToDTO(updateDentistViewModel);

            _service.Update(dentalDTO);

            return NoContent();
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete("{id}")]
        public IActionResult DeleteDentist(string id)
        {
            if (!_service.Exist(id))
            {
                return NotFound();
            }

            _service.Delete(id);

            return NoContent();
        }
    }
}
