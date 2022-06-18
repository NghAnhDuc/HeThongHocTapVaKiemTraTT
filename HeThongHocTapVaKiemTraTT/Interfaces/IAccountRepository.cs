using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface IAccountRepository
    {
        ICollection<Account> GetAccounts();
        Account GetAccount(int id);
        ICollection<Class> GetClassByAccountId(int accountId);
    }
}
