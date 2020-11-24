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

        public MedicalChartController(IMedicalChartService medicalChartService, IPatientService<PatientDTO> patientService)
        {
            _medicalChartService = medicalChartService;
            _patientService = patientService;
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
    }
}
