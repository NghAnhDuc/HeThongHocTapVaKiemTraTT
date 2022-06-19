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
        public IActionResult GetSubject(int id)
        {
            var subject = _mapper.Map<SubjectDto>(_subjectRepository.GetSubject(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(subject);
        }
        [HttpGet("class/{subjectId}")]
        public IActionResult GetClassBySubject(int subjectId)
        {
            var classes = _mapper.Map<SubjectDto>(_subjectRepository.GetClassBySubject(subjectId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(classes);
        }

    }
}
