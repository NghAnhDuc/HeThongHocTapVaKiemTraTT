using AutoMapper;
using HeThongHocTapVaKiemTraTT.Dto;
using HeThongHocTapVaKiemTraTT.Interfaces;
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
        [HttpGet("id")]
        public IActionResult GetAccountById(int id)
        {
            var account = _mapper.Map<AccountDto>(_accountRepository.GetAccount(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(account);
        }

        [HttpGet("class/{accountId}")]
        public IActionResult GetClassByAccountId(int accountId)
        {
            var classes = _mapper.Map<List<AccountDto>>(_accountRepository.GetClassByAccountId(accountId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(classes);
        }
        
    }
}
