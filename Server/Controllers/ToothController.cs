using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Diseases;
using DentistryManagement.Shared.ViewModels.Teeth;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToothController : ControllerBase
    {
        private readonly IToothService _service;

        public ToothController(IToothService service)
        {
            _service = service;
        }

        [HttpGet("{toothId}/diseases")]
        public ActionResult<IEnumerable<DiseaseViewModel>> GetToothDiseases(int toothId)
        {
            return _service.GetDiseases(toothId).Select(d => DiseaseMapper.DTOtoDiseaseVM(d)).ToArray();
        }

        [HttpPost("{toothId}/diseases")]
        public IActionResult CreateToothDiseases(int toothId, [FromBody] CreateToothDiseasesViewModel createToothDiseaseViewModel)
        {
            if (toothId != createToothDiseaseViewModel.ToothId)
            {
                return BadRequest();
            }

            if (!_service.Exist(toothId))
            {
                return NotFound();
            }

            var toothDiseasesDTO = ToothMapper.CreateToothDiseasesVMToDTO(createToothDiseaseViewModel);
            _service.CreateToothDiseases(toothDiseasesDTO);

            return Ok(ModelState);
        }
    }
}
