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
using DentistryManagement.Shared.ViewModels.TreatmentHistories;
using Microsoft.AspNetCore.Http;
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
        private readonly IFileService _fileService;
        private readonly ITreatmentHistoryService _treatmentHistoryService;
        private readonly ITreatmentService<TreatmentDTO> _treatmentService;
        private readonly IDentistService _dentistService;

        public MedicalChartController(
            IMedicalChartService medicalChartService, 
            IPatientService<PatientDTO> patientService, 
            IAllergyService allergyService,
            IFileService fileService,
            ITreatmentHistoryService treatmentHistoryService,
            ITreatmentService<TreatmentDTO> treatmentService,
            IDentistService dentistService
            )
        {
            _medicalChartService = medicalChartService;
            _patientService = patientService;
            _allergyService = allergyService;
            _fileService = fileService;
            _treatmentHistoryService = treatmentHistoryService;
            _treatmentService = treatmentService;
            _dentistService = dentistService;
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

        [HttpDelete("{medicalChartId}/files/{id}")]
        public IActionResult DeleteDelete(int medicalChartId, int id)
        {
            if (!_fileService.Exist(id, medicalChartId))
            {
                return NotFound();
            }

            _fileService.Delete(id);

            return NoContent();
        }

        [HttpGet("{medicalChartId}/treatment-histories")]
        public ActionResult<IEnumerable<TreatmentHistoryViewModel>> GetTreatmentHistories(int medicalChartId)
        {
            if (!_medicalChartService.Exist(medicalChartId))
            {
                return NotFound();
            }

            return _medicalChartService
                .GetTreatmentHistories(medicalChartId)
                .Select(th => TreatmentHistoryMapper.DTOtoTreatmentHistoryVM(th))
                .ToList();
        }

        [HttpPost("{medicalChartId}/treatment-histories")]
        public IActionResult CreateTreatmentHistory(int medicalChartId, [FromBody] CreateTreatmentHistoryViewModel createTreatmentHistory)
        {
            if (medicalChartId != createTreatmentHistory.MedicalChartId)
            {
                return BadRequest();
            }

            if (
                !_medicalChartService.Exist(medicalChartId) || 
                !_treatmentService.Exist(createTreatmentHistory.TreatmentId) ||
                (createTreatmentHistory.UserId != null && !_dentistService.Exist(createTreatmentHistory.UserId))
                )
            {
                return NotFound();
            }

            var treatmentHistoryDTO = TreatmentHistoryMapper.CreateTreatmentHistoryVMToDTO(createTreatmentHistory);
            _treatmentHistoryService.Create(treatmentHistoryDTO);

            return Ok(ModelState);
        }

        [HttpGet("{medicalChartId}/treatment-histories/{treatmentHistoryId}")]
        public ActionResult<TreatmentHistoryViewModel> GetTreatmentHistory(int medicalChartId, int treatmentHistoryId)
        {
            if (!_treatmentHistoryService.Exist(medicalChartId, treatmentHistoryId))
            {
                return NotFound();
            }

            var treatmentHistoryDTO = _treatmentHistoryService.Get(medicalChartId, treatmentHistoryId);

            return TreatmentHistoryMapper.DTOtoTreatmentHistoryVM(treatmentHistoryDTO);
        }

        [HttpPut("{medicalChartId}/treatment-histories/{treatmentHistoryId}")]
        public ActionResult<IEnumerable<AllergyViewModel>> GetAllergies(int medicalChartId, int treatmentHistoryId, UpdateTreatmentHistoryViewModel updateTreatmentHistory)
        {
            if (!_treatmentHistoryService.Exist(medicalChartId, treatmentHistoryId))
            {
                return NotFound();
            }

            var treatmentHistoryDTO = TreatmentHistoryMapper.UpdateTreatmentHistoryVMToDTO(updateTreatmentHistory);
            _treatmentHistoryService.Update(treatmentHistoryDTO);

            return NoContent();
        }

        [HttpDelete("{medicalChartId}/treatment-histories/{treatmentHistoryId}")]
        public IActionResult DeleteTreatmentHistory(int medicalChartId, int treatmentHistoryId)
        {
            if (!_treatmentHistoryService.Exist(medicalChartId, treatmentHistoryId))
            {
                return NotFound();
            }

            _treatmentHistoryService.Delete(treatmentHistoryId);

            return NoContent();
        }
    }
}
