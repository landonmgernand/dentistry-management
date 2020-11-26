using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Allergies;
using DentistryManagement.Shared.ViewModels.Files;
using DentistryManagement.Shared.ViewModels.MedicalChart;
using DentistryManagement.Shared.ViewModels.Teeth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DentistryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalChartController : ControllerBase
    {
        private readonly IMedicalChartService _medicalChartService;
        private readonly IPatientService<PatientDTO> _patientService;
        private readonly IAllergyService _allergyService;
        private readonly IFileService _fileService;
        private readonly long _fileSizeLimit;

        public MedicalChartController(
            IMedicalChartService medicalChartService, 
            IPatientService<PatientDTO> patientService, 
            IAllergyService allergyService,
            IFileService fileService,
            IConfiguration config
            )
        {
            _medicalChartService = medicalChartService;
            _patientService = patientService;
            _allergyService = allergyService;
            _fileService = fileService;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
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

        [HttpGet("{medicalChartId}/files")]
        public ActionResult<IEnumerable<FileViewModel>> GetFiles(int medicalChartId)
        {
            if (!_medicalChartService.Exist(medicalChartId))
            {
                return NotFound();
            }

            return _medicalChartService.GetFiles(medicalChartId).Select(f => FileMapper.DTOtoFiileVM(f)).ToList();
        }

        [HttpPost("{medicalChartId}/files")]
        public async Task<IActionResult> CreateFile(int medicalChartId, [FromForm] IFormFile file)
        {
            if (!_medicalChartService.Exist(medicalChartId))
            {
                return NotFound();
            }

            await _fileService.Create(medicalChartId, file);
 
            return Ok(ModelState);
        }
    }
}
