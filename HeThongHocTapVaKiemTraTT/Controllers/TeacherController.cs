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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTeachers()
        {
            var teachers = _mapper.Map<List<Teacher>>(_teacherRepository.GetTeachers());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(teachers);
        }

        [HttpGet("{teacherId}")]
        public IActionResult GetTeacher(int teacherId)
        {
            var teacher = _mapper.Map<Teacher>(_teacherRepository.GetTeacher(teacherId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(teacher);
        }

        [HttpGet("{classId}/teacher")]
        public IActionResult GetATeacherFromAClass(int classId)
        {
            var teacher = _mapper.Map<TeacherDto>(_teacherRepository.GetATeacherFromAClass(classId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(teacher);
        }

        [HttpGet("{teacherId}/classes")]
        public IActionResult GetClassByTeacher(int teacherId)
        {
            var classes = _mapper.Map<List<ClassDto>>(_teacherRepository.GetClassByTeacher(teacherId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(classes);
        }

        [HttpPost]
        public IActionResult CreateTeacher([FromBody] TeacherDto teacherCreate)
        {
            if (teacherCreate == null)
                return BadRequest(ModelState);

            var teacher = _teacherRepository.GetTeachers()
                .Where(p => p.Id == teacherCreate.Id)
                .FirstOrDefault();

            if (teacher != null)
            {
                ModelState.AddModelError("", "Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var teacherMap = _mapper.Map<Teacher>(teacherCreate);

            if (!_teacherRepository.CreateTeacher(teacherMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{teacherId}")]
        public IActionResult UpdateTeacher(int teacherId, [FromBody] TeacherDto updatedTeacher)
        {
            if (updatedTeacher == null)
                return BadRequest(ModelState);

            if (teacherId != updatedTeacher.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var teacherMap = _mapper.Map<Teacher>(updatedTeacher);

            if (!_teacherRepository.UpdateTeacher(teacherMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{teacherId}")]
        public IActionResult DeleteTeacher(int teacherId)
        {
            var teacherToDelete = _teacherRepository.GetTeacher(teacherId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teacherRepository.DeleteTeacher(teacherToDelete))
            {
                ModelState.AddModelError("", "Somthing went wrong while deleting");
            }

            return NoContent();
        }
    }
}
