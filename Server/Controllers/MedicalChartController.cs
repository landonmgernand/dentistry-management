using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.MedicalChart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalChartController : ControllerBase
    {
        private readonly IMedicalChartService<MedicalChartDTO> _medicalChartService;
        private readonly IPatientService<PatientDTO> _patientService;

        public MedicalChartController(IMedicalChartService<MedicalChartDTO> medicalChartService, IPatientService<PatientDTO> patientService)
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
    }
}
