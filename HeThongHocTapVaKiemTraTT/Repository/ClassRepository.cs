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

        public bool CreateClass(Class classs)
        {
            _context.Add(classs);
            return Save();
        }

        public bool DeleteClass(Class classs)
        {
            _context.Remove(classs);
            return Save();
        }

        public Class GetClass(int id)
        {
            return _context.Classes.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Class> GetClasses()
        {
           return _context.Classes.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateClass(int subjectId, int teacherId, int semesterId, int scheduleId, Class classs)
        {
            _context.Update(classs);
            return Save();
        }
    }
}
