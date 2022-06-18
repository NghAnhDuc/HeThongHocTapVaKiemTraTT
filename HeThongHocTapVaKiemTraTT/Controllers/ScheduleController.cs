using AutoMapper;
using HeThongHocTapVaKiemTraTT.Dto;
using HeThongHocTapVaKiemTraTT.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeThongHocTapVaKiemTraTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetSchedules()
        {
            var schedules = _mapper.Map<List<ScheduleDto>>(_scheduleRepository.GetSchedules());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(schedules);
        }
        [HttpGet("id")]
        public IActionResult GetSchedule(int id)
        {
            var schedule = _mapper.Map<ScheduleDto>(_scheduleRepository.GetSchedule(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(schedule);
        }
    }
}
