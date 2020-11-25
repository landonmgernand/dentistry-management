using System.Collections.Generic;
using System.Linq;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Allergies;
using DentistryManagement.Shared.ViewModels.MedicalChart;
using DentistryManagement.Shared.ViewModels.Teeth;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalChartController : ControllerBase
    {
        private readonly IMedicalChartService _medicalChartService;
        private readonly IPatientService<PatientDTO> _patientService;
        private readonly IAllergyService _allergyService;

        public MedicalChartController(IMedicalChartService medicalChartService, IPatientService<PatientDTO> patientService, IAllergyService allergyService)
        {
            _medicalChartService = medicalChartService;
            _patientService = patientService;
            _allergyService = allergyService;
        }

    
        public ActionResult<MedicalChartViewModel> Get(int patientId)
        {
            var medicalChart = _medicalChartService.Get(patientId);

            if (medicalChart is null)
            {
                return NotFound();
            }

            return MedicalChartMapper.DTOtoMedicalChartVM(medicalChart);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OpenMedicalChartViewModel openMedical)
        {
            if (!_patientService.Exist(openMedical.PatientId))
            {
                return NotFound();
            }

            _medicalChartService.Create(openMedical.PatientId);

            return Ok(ModelState);
        }

        [HttpGet("{medicalChartId}/teeth")]
        public ActionResult<TeethCategoryViewModel> GetTeeth(int medicalChartId)
        {
            if (!_medicalChartService.Exist(medicalChartId))
            {
                return NotFound();
            }

            var medicalChart = _medicalChartService.GetTeeth(medicalChartId);

            return ToothMapper.TeethCategoryDTOtoVM(medicalChart);
        }

        [HttpGet("{medicalChartId}/allergies")]
        public ActionResult<IEnumerable<AllergyViewModel>> GetAllergies(int medicalChartId)
        {
            if (!_medicalChartService.Exist(medicalChartId))
            {
                return NotFound();
            }

            return _medicalChartService.GetAllergies(medicalChartId).Select(a => AllergyMapper.DTOtoAllergyVM(a)).ToList();
        }

        [HttpPost("{medicalChartId}/allergies")]
        public IActionResult CreateAllergy(int medicalChartId, [FromBody] CreateAllergyViewModel createAllergy)
        {
            if (medicalChartId != createAllergy.MedicalChartId)
            {
                return BadRequest();
            }

            if (!_medicalChartService.Exist(medicalChartId))
            {
                return NotFound();
            }

            var allergyDTO = AllergyMapper.CreateAllergyVMToDTO(createAllergy);
            _allergyService.Create(allergyDTO);

            return Ok(ModelState);
        }

        [HttpDelete("{medicalChartId}/allergies/{id}")]
        public IActionResult DeleteAllergy(int medicalChartId, int id)
        {
            if (!_allergyService.Exist(id, medicalChartId))
            {
                return NotFound();
            }

            _allergyService.Delete(id);

            return NoContent();
        }
    }
}
