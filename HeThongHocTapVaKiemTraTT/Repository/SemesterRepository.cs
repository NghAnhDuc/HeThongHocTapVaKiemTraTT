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

        public Semester GetSemester(int id)
        {
            return _context.Semesters.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Semester> GetSemesters()
        {
            return _context.Semesters.OrderBy(p => p.Id).ToList();
        }
    }
}
