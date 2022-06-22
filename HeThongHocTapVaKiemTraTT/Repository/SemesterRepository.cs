using HeThongHocTapVaKiemTraTT.Data;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Repository
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly DataContext _context;

        public SemesterRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSemester(Semester semester)
        {
            _context.Add(semester);
            return Save();
        }

        public bool DeleteSemester(Semester semester)
        {
            _context.Remove(semester);
            return Save();
        }

        public ICollection<Class> GetClassBySemester(int semesterId)
        {
            return _context.Classes.Where(p => p.Semester.Id == semesterId).ToList();
        }

        public Semester GetSemester(int id)
        {
            return _context.Semesters.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Semester> GetSemesters()
        {
            return _context.Semesters.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateSemester(Semester semester)
        {
            _context.Update(semester);
            return Save();
        }
    }
}
