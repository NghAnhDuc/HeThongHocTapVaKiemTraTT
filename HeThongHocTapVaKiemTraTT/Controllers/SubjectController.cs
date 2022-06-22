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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _mapper.Map<List<SubjectDto>>(_subjectRepository.GetSubjects());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(subjects);
        }

        [HttpGet("{subjectId}")]
        public IActionResult GetSubject(int subjectId)
        {
            var subject = _mapper.Map<SubjectDto>(_subjectRepository.GetSubject(subjectId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(subject);
        }

        [HttpGet("{subjectId}/classes")]
        public IActionResult GetClassBySubject(int subjectId)
        {
            var classes = _mapper.Map<List<ClassDto>>(_subjectRepository.GetClassBySubject(subjectId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(classes);
        }

        [HttpPost]
        public IActionResult CreateSubject([FromBody] SubjectDto subjectCreate)
        {
            if (subjectCreate == null)
                return BadRequest(ModelState);

            var subject = _subjectRepository.GetSubjects()
                .Where(p => p.Name.Trim().ToUpper() == subjectCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (subject != null)
            {
                ModelState.AddModelError("", "Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subjectMap = _mapper.Map<Subject>(subjectCreate);

            if (!_subjectRepository.CreateSubject(subjectMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{subjectId}")]
        public IActionResult UpdateSubject(int subjectId, [FromBody] SubjectDto updatedSubject)
        {
            if (updatedSubject == null)
                return BadRequest(ModelState);

            if (subjectId != updatedSubject.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var subjectMap = _mapper.Map<Subject>(updatedSubject);

            if (!_subjectRepository.UpdateSubject(subjectMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{subjectId}")]
        public IActionResult DeleteSubject(int subjectId)
        {
            var subjectToDelete = _subjectRepository.GetSubject(subjectId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_subjectRepository.DeleteSubject(subjectToDelete))
            {
                ModelState.AddModelError("", "Somthing went wrong while deleting");
            }

            return NoContent();
        }
    }
}
