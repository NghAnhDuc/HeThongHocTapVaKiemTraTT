using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface ITestRepository
    {
        ICollection<Test> GetTests();
        Test GetTest(int id);
        bool CreateTest(Test test);
        bool UpdateTest(int subjectId, int teacherId, int accountId, int scheduleId, Test test);
        bool DeleteTest(Test test);
        bool Save();
    }
}
