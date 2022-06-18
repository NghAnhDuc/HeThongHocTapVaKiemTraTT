using HeThongHocTapVaKiemTraTT.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeThongHocTapVaKiemTraTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterRepository _semesterRepository;

        public SemesterController(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }
        [HttpGet]
        public IActionResult GetSemesters()
        {
            var semesters = _semesterRepository.GetSemesters();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(semesters);
        }
    }
}
