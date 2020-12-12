using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Treatments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService<TreatmentDTO> _service;

        public TreatmentController(ITreatmentService<TreatmentDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TreatmentViewModel>> GetTreatments()
        {
            return _service.GetAll().Select(t => TreatmentMapper.DTOtoTreatmentVM(t)).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<TreatmentViewModel> GetTreatment(int id)
        {
            var treatmentDTO = _service.Get(id);

            if (treatmentDTO is null)
            {
                return NotFound();
            }

            return TreatmentMapper.DTOtoTreatmentVM(treatmentDTO);
        }

        [HttpPost]
        public IActionResult CreateTreatment([FromBody] CreateTreatmentViewModel createTreatment)
        {
            var treatmentDTO = TreatmentMapper.CreateTreatmentVMToDTO(createTreatment);
            _service.Create(treatmentDTO);

            return Ok(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTreatment(int id, [FromBody] UpdateTreatmentViewModel updateTreatment)
        {
            if (id != updateTreatment.Id)
            {
                return BadRequest();
            }

            if (!_service.Exist(id))
            {
                return NotFound();
            }

            var treatmentDTO = TreatmentMapper.UpdateTreatmentVMToDTO(updateTreatment);
            _service.Update(treatmentDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTreatment(int id)
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
