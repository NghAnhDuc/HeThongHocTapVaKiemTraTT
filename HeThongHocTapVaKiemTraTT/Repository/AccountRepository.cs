using HeThongHocTapVaKiemTraTT.Data;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateAccount(Account account)
        {
            _context.Add(account);
            return Save();
        }

        public bool DeleteAccount(Account account)
        {
            _context.Remove(account);
            return Save();
        }

        public Account GetAccount(int id)
        {
            return _context.Accounts.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }

        public ICollection<Scoreboard> GetScoreboardByAccount(int accountId)
        {
            return _context.Scoreboards.Where(p => p.Account.Id == accountId).ToList();
        }

        public ICollection<Test> GetTestByAccount(int accountId)
        {
            return _context.Tests.Where(p => p.Account.Id == accountId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAccount(Account account)
        {
            _context.Update(account);
            return Save();
        }
    }
}
