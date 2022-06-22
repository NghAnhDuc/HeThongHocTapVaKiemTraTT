using AutoMapper;
using HeThongHocTapVaKiemTraTT.Dto;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;
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

        [HttpGet("{scheduleId}")]
        public IActionResult GetSchedule(int scheduleId)
        {
            var schedule = _mapper.Map<ScheduleDto>(_scheduleRepository.GetSchedule(scheduleId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(schedule);
        }

        [HttpPost]
        public IActionResult CreateSchedule([FromBody] ScheduleDto scheduleCreate)
        {
            if (scheduleCreate == null)
                return BadRequest(ModelState);

            var schedule = _scheduleRepository.GetSchedules()
                .Where(p => p.Id == scheduleCreate.Id)
                .FirstOrDefault();

            if (schedule != null)
            {
                ModelState.AddModelError("", "Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var scheduleMap = _mapper.Map<Schedule>(scheduleCreate);

            if (!_scheduleRepository.CreateSchedule(scheduleMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{scheduleId}")]
        public IActionResult UpdateSchedule(int scheduleId, [FromBody] ScheduleDto updatedSchedule)
        {
            if (updatedSchedule == null)
                return BadRequest(ModelState);

            if (scheduleId != updatedSchedule.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var scheduleMap = _mapper.Map<Schedule>(updatedSchedule);

            if (!_scheduleRepository.UpdateSchedule(scheduleMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{scheduleId}")]
        public IActionResult DeleteSchedule(int scheduleId)
        {
            var scheduleToDelete = _scheduleRepository.GetSchedule(scheduleId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_scheduleRepository.DeleteSchedule(scheduleToDelete))
            {
                ModelState.AddModelError("", "Somthing went wrong while deleting");
            }

            return NoContent();
        }
    }
}
