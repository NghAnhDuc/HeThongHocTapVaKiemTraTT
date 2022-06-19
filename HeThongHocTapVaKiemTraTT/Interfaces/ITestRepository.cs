using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface ITestRepository
    {
        ICollection<Test> GetTests();
        Test GetTest(int id);
    }
}
