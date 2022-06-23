using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface ISemesterRepository
    {
        ICollection<Semester> GetSemesters();
        Semester GetSemester(int id);
        ICollection<Class> GetClassBySemester(int semesterId);
        bool CreateSemester(Semester semester);
        bool UpdateSemester(Semester semester);
        bool DeleteSemester(Semester semester);
        bool Save();
    }
}
