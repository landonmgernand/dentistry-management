using System.Collections.Generic;
using System.Linq;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Patients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService<PatientDTO> _service;

        public PatientController(IPatientService<PatientDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientViewModel>> GetPatients()
        {
            return _service.GetAll().Select(p => PatientMapper.DTOtoPatientVM(p)).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<PatientViewModel> GetPatient(int id)
        {
            var patientDTO = _service.Get(id);

            if (patientDTO is null)
            {
                return NotFound();
            }

            return PatientMapper.DTOtoPatientVM(patientDTO);
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody] CreatePatientViewModel createPatientViewModel)
        {
            var patientDTO = PatientMapper.CreatePatientVMToDTO(createPatientViewModel);
            _service.Create(patientDTO);

            return Ok(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, UpdatePatientViewModel updatePatientViewModel)
        {
            if (id != updatePatientViewModel.Id)
            {
                return BadRequest();
            }

            if (!_service.Exist(id))
            {
                return NotFound();
            }

            var patientDTO = PatientMapper.UpdatePatientVMToDTO(updatePatientViewModel);
            _service.Update(patientDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
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
