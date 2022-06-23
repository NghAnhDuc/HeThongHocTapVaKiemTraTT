using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface IAccountRepository
    {
        ICollection<Account> GetAccounts();
        Account GetAccount(int id);
        ICollection<Test> GetTestByAccount(int accountId);
        ICollection<Scoreboard> GetScoreboardByAccount(int accountId);
        bool CreateAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(Account account);
        bool Save();
    }
}
