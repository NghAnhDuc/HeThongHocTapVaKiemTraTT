using HeThongHocTapVaKiemTraTT.Data;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext _context;

        public TestRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateTest(Test test)
        {
            _context.Add(test);
            return Save();
        }

        public bool DeleteTest(Test test)
        {
            _context.Remove(test);
            return Save();
        }

        public Test GetTest(int id)
        {
            return _context.Tests.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Test> GetTests()
        {
            return _context.Tests.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateTest(int subjectId, int teacherId, int accountId, int scheduleId, Test test)
        {
            _context.Update(test);
            return Save();
        }
    }
}
