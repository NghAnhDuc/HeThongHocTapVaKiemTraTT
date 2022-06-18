﻿using HeThongHocTapVaKiemTraTT.Data;
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
  
        public Account GetAccount(int id)
        {
            return _context.Accounts.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Account> GetAccounts()
        {
            return _context.Accounts.OrderBy(p => p.Id).ToList();
        }

        public ICollection<Class> GetClassByAccountId(int accountId)
        {
            return _context.AccountClasses.Where(p => p.AccountId == accountId).Select(e => e.Class).ToList();
        }
    }
}