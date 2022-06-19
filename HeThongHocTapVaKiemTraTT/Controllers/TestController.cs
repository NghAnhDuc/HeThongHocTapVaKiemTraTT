using AutoMapper;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeThongHocTapVaKiemTraTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestController(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTests()
        {
            var tests = _mapper.Map<List<Test>>(_testRepository.GetTests());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(tests);
        }
        [HttpGet("{testId}")]
        public IActionResult GetTest(int id)
        {
            var test = _mapper.Map<Test>(_testRepository.GetTest(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(test);
        }

    }
}
