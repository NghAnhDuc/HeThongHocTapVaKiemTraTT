using AutoMapper;
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
        public IActionResult GetTeacher(int id)
        {
            var teacher = _mapper.Map<Teacher>(_teacherRepository.GetTeacher(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(teacher);
        }
        [HttpGet("teacher/{classId}")]
        public IActionResult GetATeacherFromAClass(int classId)
        {
            var n = _mapper.Map<Teacher>(_teacherRepository.GetATeacherFromAClass(classId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(n);
        }
        [HttpGet("class/{teacherId}")]
        public IActionResult GetClassByTeacher(int teacherId)
        {
            var classes = _mapper.Map<List<Teacher>>(_teacherRepository.GetClassByTeacher(teacherId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(classes);
        }
    }
}
