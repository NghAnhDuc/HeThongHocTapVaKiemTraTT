﻿using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface IClassRepository
    {
        ICollection<Class> GetClasses();
        Class GetClass(int id);
        ICollection<Account> GetAccountByClass(int classId);
    }
}
