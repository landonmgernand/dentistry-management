using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Schedule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService<ScheduleDTO> _scheduleService;
        private readonly IPatientService<PatientDTO> _patientService;

        public ScheduleController(IScheduleService<ScheduleDTO> scheduleService, IPatientService<PatientDTO> patientService)
        {
            _scheduleService = scheduleService;
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScheduleViewModel>> GetSchedule()
        {
            return _scheduleService.GetAll().Select(s => ScheduleMapper.DTOtoScheduleVM(s)).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<ScheduleViewModel> GetScheduleItem(int id)
        {
            var scheduleDTO = _scheduleService.Get(id);

            if (scheduleDTO is null)
            {
                return NotFound();
            }

            return ScheduleMapper.DTOtoScheduleVM(scheduleDTO);
        }

        [HttpPost]
        public IActionResult CreateSchedule([FromBody] CreateScheduleViewModel createSchedule)
        {
            if (!_patientService.Exist(createSchedule.PatientId))
            {
                return NotFound();
            }

            var scheduleDTO = ScheduleMapper.CreateScheduleVMtoDTO(createSchedule);
            _scheduleService.Create(scheduleDTO);

            return Ok(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchedule(int id, [FromBody] UpdateScheduleViewModel updateSchedule)
        {
            if (id != updateSchedule.Id)
            {
                return BadRequest();
            }

            if (!_scheduleService.Exist(id))
            {
                return NotFound();
            }

            var scheduleDTO = ScheduleMapper.UpdateScheduleVMToDTO(updateSchedule);
            _scheduleService.Update(scheduleDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule (int id)
        {
            if (!_scheduleService.Exist(id))
            {
                return NotFound();
            }

            _scheduleService.Delete(id);

            return NoContent();
        }
    }
}
