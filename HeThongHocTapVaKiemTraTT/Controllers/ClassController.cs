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
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISemesterRepository _semesterRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ClassController(IClassRepository classRepository, 
            ISubjectRepository subjectRepository, 
            ITeacherRepository teacherRepository,
            ISemesterRepository semesterRepository, 
            IScheduleRepository scheduleRepository, 
            IMapper mapper)
        {
            _classRepository = classRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _semesterRepository = semesterRepository;
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetClasses()
        {
            var classes = _mapper.Map<List<ClassDto>>(_classRepository.GetClasses());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(classes);
        }

        [HttpGet("{classId}")]
        public IActionResult GetClass(int classId)
        {
            var x = _mapper.Map<ClassDto>(_classRepository.GetClass(classId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(x);
        }

        [HttpPost]
        public IActionResult CreateClass([FromQuery] int subjectId, 
            [FromQuery] int teacherId, 
            [FromQuery] int semesterId, 
            [FromQuery] int scheduleId, 
            [FromBody] ClassDto classCreate)
        {
            if (classCreate == null)
                return BadRequest(ModelState);

            var classs = _classRepository.GetClasses()
                .Where(p => p.Id == classCreate.Id)
                .FirstOrDefault();

            if (classs != null)
            {
                ModelState.AddModelError("", "Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var classMap = _mapper.Map<Class>(classCreate);

            classMap.Subject = _subjectRepository.GetSubject(subjectId); 
            classMap.Teacher = _teacherRepository.GetTeacher(teacherId);
            classMap.Semester = _semesterRepository.GetSemester(semesterId);
            classMap.Schedule = _scheduleRepository.GetSchedule(scheduleId);

            if (!_classRepository.CreateClass(classMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{classId}")]
        public IActionResult UpdateClass(int classId, 
            [FromQuery] int subjectId,
            [FromQuery] int teacherId,
            [FromQuery] int semesterId,
            [FromQuery] int scheduleId,
            [FromBody] ClassDto updatedClass)
        {
            if (updatedClass == null)
                return BadRequest(ModelState);

            if (classId != updatedClass.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var classMap = _mapper.Map<Class>(updatedClass);

            if (!_classRepository.UpdateClass(subjectId, teacherId, semesterId, scheduleId, classMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{classId}")]
        public IActionResult DeleteClass(int classId)
        {
            var classToDelete = _classRepository.GetClass(classId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_classRepository.DeleteClass(classToDelete))
            {
                ModelState.AddModelError("", "Somthing went wrong while deleting");
            }

            return NoContent();
        }
    }
}
