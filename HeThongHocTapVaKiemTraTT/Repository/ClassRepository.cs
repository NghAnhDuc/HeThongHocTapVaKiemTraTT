using HeThongHocTapVaKiemTraTT.Data;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly DataContext _context;

        public ClassRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Account> GetAccountByClassId(int classId)
        {
            return _context.AccountClasses.Where(p => p.ClassId == classId).Select(c => c.Account).ToList();
        }

        public Class GetClass(int id)
        {
            return _context.Classes.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Class> GetClasses()
        {
           return _context.Classes.OrderBy(p => p.Id).ToList();
        }
    }
}
