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
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterRepository _semesterRepository;
        private readonly IMapper _mapper;

        public SemesterController(ISemesterRepository semesterRepository, IMapper mapper)
        {
            _semesterRepository = semesterRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSemesters()
        {
            var semesters = _mapper.Map<List<SemesterDto>>(_semesterRepository.GetSemesters());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(semesters);
        }

        [HttpGet("{semesterId}")]
        public IActionResult GetSemester(int semesterId)
        {
            var semester = _mapper.Map<SemesterDto>(_semesterRepository.GetSemester(semesterId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(semester);
        }

        [HttpGet("{semesterId}/classes")]
        public IActionResult GetClassBySemester(int semesterId)
        {
            var classes = _mapper.Map<List<ClassDto>>(_semesterRepository.GetClassBySemester(semesterId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(classes);
        }

        [HttpPost]
        public IActionResult CreateSemester([FromBody] SemesterDto semesterCreate)
        {
            if (semesterCreate == null)
                return BadRequest(ModelState);

            var semester = _semesterRepository.GetSemesters()
                .Where(p => p.Name.Trim().ToUpper() == semesterCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (semester != null)
            {
                ModelState.AddModelError("", "Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var semesterMap = _mapper.Map<Semester>(semesterCreate);

            if (!_semesterRepository.CreateSemester(semesterMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{semesterId}")]
        public IActionResult UpdateSemester(int semesterId, [FromBody] SemesterDto updatedSemester)
        {
            if (updatedSemester == null)
                return BadRequest(ModelState);

            if (semesterId != updatedSemester.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var semesterMap = _mapper.Map<Semester>(updatedSemester);

            if (!_semesterRepository.UpdateSemester(semesterMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{semesterId}")]
        public IActionResult DeleteSemester(int semesterId)
        {
            var semesterToDelete = _semesterRepository.GetSemester(semesterId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_semesterRepository.DeleteSemester(semesterToDelete))
            {
                ModelState.AddModelError("", "Somthing went wrong while deleting");
            }

            return NoContent();
        }
    }
}
