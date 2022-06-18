using HeThongHocTapVaKiemTraTT.Data;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Repository
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly MyDbContext _context;

        public SemesterRepository(MyDbContext context)
        {
            _context = context;
        }

        public Semester GetSemester(string name)
        {
            return _context.Semesters.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Semester> GetSemesters()
        {
            return _context.Semesters.OrderBy(p => p.Id).ToList();
        }
    }
}
