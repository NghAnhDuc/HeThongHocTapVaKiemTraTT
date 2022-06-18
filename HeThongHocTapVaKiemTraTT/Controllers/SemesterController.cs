﻿using AutoMapper;
using HeThongHocTapVaKiemTraTT.Dto;
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

        [HttpGet("id")]
        public IActionResult GetSemesterById(int id)
        {
            var semester = _mapper.Map<SemesterDto>(_semesterRepository.GetSemester(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(semester);
        }
    }
}
