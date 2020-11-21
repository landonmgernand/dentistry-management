using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Diseases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService<DiseaseDTO> _service;

        public DiseaseController(IDiseaseService<DiseaseDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DiseaseViewModel>> GetDiseases()
        {
            return _service.GetAll().Select(d => DiseaseMapper.DTOtoDiseaseVM(d)).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<DiseaseViewModel> GetDisease(int id)
        {
            var diseaseDTO = _service.Get(id);

            if (diseaseDTO is null)
            {
                return NotFound();
            }

            return DiseaseMapper.DTOtoDiseaseVM(diseaseDTO);
        }

        [HttpPost]
        public IActionResult CreateDisease([FromBody] CreateDiseaseViewModel createDisease)
        {
            var diseaseDTO = DiseaseMapper.CreateDiseaseVMToDTO(createDisease);
            _service.Create(diseaseDTO);

            return Ok(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDisease(int id, UpdateDiseaseViewModel updateDisease)
        {
            if (id != updateDisease.Id)
            {
                return BadRequest();
            }

            if (!_service.Exist(id))
            {
                return NotFound();
            }

            var diseaseDTO = DiseaseMapper.UpdateDiseaseVMToDTO(updateDisease);
            _service.Update(diseaseDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDisease(int id)
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
