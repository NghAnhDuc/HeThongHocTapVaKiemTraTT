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
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAccounts()
        {
            var accounts = _mapper.Map<List<AccountDto>>(_accountRepository.GetAccounts());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(accounts);
        }

        [HttpGet("{accountId}")]
        public IActionResult GetAccount(int accountId)
        {
            var account = _mapper.Map<AccountDto>(_accountRepository.GetAccount(accountId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(account);
        }

        [HttpGet("{accountId}/tests")]
        public IActionResult GetTestByAccount(int accountId)
        {
            var tests = _mapper.Map<List<TestDto>>(_accountRepository.GetTestByAccount(accountId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(tests);
        }

        [HttpGet("{accountId}/scoreboards")]
        public IActionResult GetScoreboardByAccount(int accountId)
        {
            var scoreboards = _mapper.Map<List<ScoreboardDto>>(_accountRepository.GetScoreboardByAccount(accountId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(scoreboards);
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] AccountDto accountCreate)
        {
            if (accountCreate == null)
                return BadRequest(ModelState);

            var account = _accountRepository.GetAccounts()
                .Where(p => p.Email.ToUpper() == accountCreate.Email.ToUpper())
                .FirstOrDefault();

            if (account != null)
            {
                ModelState.AddModelError("", "Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountMap = _mapper.Map<Account>(accountCreate);

            if (!_accountRepository.CreateAccount(accountMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{accountId}")]
        public IActionResult UpdateAccount(int accountId, [FromBody] AccountDto updatedAccount)
        {
           

            if (updatedAccount == null)
                return BadRequest(ModelState);

            if (accountId != updatedAccount.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();


            var accountMap = _mapper.Map<Account>(updatedAccount);

            if (!_accountRepository.UpdateAccount(accountMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{accountId}")]
        public IActionResult DeleteAccount(int accountId)
        {
            var accountToDelete = _accountRepository.GetAccount(accountId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_accountRepository.DeleteAccount(accountToDelete))
            {
                ModelState.AddModelError("", "Somthing went wrong while deleting");
            }

            return NoContent();
        }
    }
}
