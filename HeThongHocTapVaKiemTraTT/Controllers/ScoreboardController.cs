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
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public ScoreboardController(IScoreboardRepository scoreboardRepository, 
            IAccountRepository accountRepository, 
            IMapper mapper)
        {
            _scoreboardRepository = scoreboardRepository;
            _accountRepository = accountRepository;
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
        public IActionResult GetScoreboard(int scoreboardId)
        {
            var scoreboard = _mapper.Map<ScoreboardDto>(_scoreboardRepository.GetScoreboard(scoreboardId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(scoreboard);
        }

        [HttpPost]
        public IActionResult CreateScoreboard([FromQuery] int accountId, [FromBody] ScoreboardDto scoreboardCreate)
        {
            if (scoreboardCreate == null)
                return BadRequest(ModelState);

            var scoreboard = _scoreboardRepository.GetScoreboards()
                .Where(p => p.Id == scoreboardCreate.Id)
                .FirstOrDefault();

            if (scoreboard != null)
            {
                ModelState.AddModelError("", "Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var scoreboardMap = _mapper.Map<Scoreboard>(scoreboardCreate);

            scoreboardMap.Account = _accountRepository.GetAccount(accountId);

            if (!_scoreboardRepository.CreateScoreboard(scoreboardMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{scoreboardId}")]
        public IActionResult UpdateScoreboard(int scoreboardId, [FromBody] ScoreboardDto updatedScoreboard)
        {
            if (updatedScoreboard == null)
                return BadRequest(ModelState);

            if (scoreboardId != updatedScoreboard.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var scoreboardMap = _mapper.Map<Scoreboard>(updatedScoreboard);

            if (!_scoreboardRepository.UpdateScoreboard(scoreboardMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{scoreboardId}")]
        public IActionResult DeleteScoreboard(int scoreboardId)
        {
            var scoreboardToDelete = _scoreboardRepository.GetScoreboard(scoreboardId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_scoreboardRepository.DeleteScoreboard(scoreboardToDelete))
            {
                ModelState.AddModelError("", "Somthing went wrong while deleting");
            }

            return NoContent();
        }
    }
}
