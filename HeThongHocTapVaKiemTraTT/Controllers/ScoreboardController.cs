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
    public class ScoreboardController : ControllerBase
    {
        private readonly IScoreboardRepository _scoreboardRepository;
        private readonly IMapper _mapper;

        public ScoreboardController(IScoreboardRepository scoreboardRepository, IMapper mapper)
        {
            _scoreboardRepository = scoreboardRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetScoreboards()
        {
            var scoreboards = _mapper.Map<List<ScoreboardDto>>(_scoreboardRepository.GetScoreboards());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(scoreboards);
        }
        [HttpGet("{scoreboardId}")]
        public IActionResult GetScoreboard(int id)
        {
            var scoreboard = _mapper.Map<ScoreboardDto>(_scoreboardRepository.GetScoreboard(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(scoreboard);
        }
    }
}
