using AutoMapper;
using HeThongHocTapVaKiemTraTT.Dto;
using HeThongHocTapVaKiemTraTT.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeThongHocTapVaKiemTraTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassController(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
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
        [HttpGet("id")]
        public IActionResult GetClassById(int id)
        {
            var x = _mapper.Map<ClassDto>(_classRepository.GetClass(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(x);
        }
        [HttpGet("account/{classId}")]
        public IActionResult GetAccountByClassId(int classId)
        {
            var accounts = _mapper.Map<List<ClassDto>>(_classRepository.GetAccountByClassId(classId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(accounts);
        }

    }
}
