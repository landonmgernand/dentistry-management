using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Allergies;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IMedicalChartService _medicalChartService;
        private readonly IAllergyService _allergyService;

        public AllergyController(IMedicalChartService medicalChartService, IAllergyService allergyService)
        {
            _medicalChartService = medicalChartService;
            _allergyService = allergyService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAllergyViewModel createAllergy)
        {
            if (!_medicalChartService.Exist(createAllergy.MedicalChartId))
            {
                return NotFound();
            }

            var allergyDTO = AllergyMapper.CreateAllergyVMToDTO(createAllergy);
            _allergyService.Create(allergyDTO);

            return Ok(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_allergyService.Exist(id))
            {
                return NotFound();
            }

            _allergyService.Delete(id);

            return NoContent();
        }
    }
}
