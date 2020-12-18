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
        private readonly IAffiliateService<AffiliateDTO> _affiliateService;
        private readonly IUserService _userService;

        public ScheduleController(
            IScheduleService<ScheduleDTO> scheduleService, 
            IPatientService<PatientDTO> patientService,
            IAffiliateService<AffiliateDTO> affiliateService,
            IUserService userService
            )
        {
            _scheduleService = scheduleService;
            _patientService = patientService;
            _affiliateService = affiliateService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScheduleViewModel>> GetSchedule()
        {
            return _scheduleService.GetAll().Select(s => ScheduleMapper.DTOtoScheduleVM(s)).ToArray();
        }

        [HttpGet("{affiliateId}")]
        public ActionResult<IEnumerable<ScheduleViewModel>> GetSchedule(int affiliateId)
        {
            if (!_affiliateService.Exist(affiliateId))
            {
                return NotFound();
            }

            return _scheduleService.GetAffiliateSchedule(affiliateId).Select(s => ScheduleMapper.DTOtoScheduleVM(s)).ToArray();
        }

        [HttpPost]
        public IActionResult CreateSchedule([FromBody] CreateScheduleViewModel createSchedule)
        {
            if (!_patientService.Exist(createSchedule.PatientId) && !_userService.Exist(createSchedule.UserId))
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

            if (!_scheduleService.Exist(id) && !_userService.Exist(updateSchedule.UserId))
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
