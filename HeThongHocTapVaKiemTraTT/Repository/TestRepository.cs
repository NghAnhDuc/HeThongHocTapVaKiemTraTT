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
        public Test GetTest(int id)
        {
            return _context.Tests.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Test> GetTests()
        {
            return _context.Tests.OrderBy(p => p.Id).ToList();
        }
    }
}
