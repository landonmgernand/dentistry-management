using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Statistics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistryManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _service;

        public StatisticController(IStatisticService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<StatisticViewModel> GetStatistic()
        {
            var statisticDTO = _service.Get();
            return StatisticMapper.DTOtoVM(statisticDTO);
        }

        [HttpGet("{affiliateId}")]
        public ActionResult<StatisticViewModel> GetSpecifiicStatistic(int affiliateId)
        {
            var statisticDTO = _service.Get(affiliateId);
            return StatisticMapper.DTOtoVM(statisticDTO);
        }
    }
}
