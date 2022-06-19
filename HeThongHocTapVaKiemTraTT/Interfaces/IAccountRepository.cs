using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface IAccountRepository
    {
        ICollection<Account> GetAccounts();
        Account GetAccount(int id);
        ICollection<Class> GetClassByAccount(int accountId);
        ICollection<Test> GetTestByAccount(int accountId);
        ICollection<Scoreboard> GetScoreboardByAccount(int accountId);
    }
}
