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
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public TestController(ITestRepository testRepository, 
            ISubjectRepository subjectRepository, 
            ITeacherRepository teacherRepository,
            IAccountRepository accountRepository, 
            IScheduleRepository scheduleRepository, 
            IMapper mapper)
        {
            _testRepository = testRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _accountRepository = accountRepository;
            _scheduleRepository = scheduleRepository;
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
        public IActionResult GetTest(int testId)
        {
            var test = _mapper.Map<Test>(_testRepository.GetTest(testId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(test);
        }

        [HttpPost]
        public IActionResult CreateTest([FromQuery] int subjectId, 
            [FromQuery] int teacherId, 
            [FromQuery] int accountId, 
            [FromQuery] int scheduleId, 
            [FromBody] TestDto testCreate)
        {
            if (testCreate == null)
                return BadRequest(ModelState);

            var test = _testRepository.GetTests()
                .Where(p => p.Id == testCreate.Id)
                .FirstOrDefault();

            if (test != null)
            {
                ModelState.AddModelError("", "Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var testMap = _mapper.Map<Test>(testCreate);

            testMap.Subject = _subjectRepository.GetSubject(subjectId);
            testMap.Teacher = _teacherRepository.GetTeacher(teacherId);
            testMap.Account = _accountRepository.GetAccount(accountId);
            testMap.Schedule = _scheduleRepository.GetSchedule(scheduleId);

            if (!_testRepository.CreateTest(testMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{testId}")]
        public IActionResult UpdateTest(int testId,
            [FromQuery] int subjectId,
            [FromQuery] int teacherId,
            [FromQuery] int accountId,
            [FromQuery] int scheduleId,
            [FromBody] TestDto updatedTest)
        {
            if (updatedTest == null)
                return BadRequest(ModelState);

            if (testId != updatedTest.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var testMap = _mapper.Map<Test>(updatedTest);

            if (!_testRepository.UpdateTest(subjectId, teacherId, accountId, scheduleId, testMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{testId}")]
        public IActionResult DeleteTest(int testId)
        {
            var testToDelete = _testRepository.GetTest(testId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_testRepository.DeleteTest(testToDelete))
            {
                ModelState.AddModelError("", "Somthing went wrong while deleting");
            }

            return NoContent();
        }
    }
}
