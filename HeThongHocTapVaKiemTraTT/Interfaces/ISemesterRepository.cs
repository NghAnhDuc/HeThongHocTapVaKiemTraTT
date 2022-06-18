using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface ISemesterRepository
    {
        ICollection<Semester> GetSemesters();
        Semester GetSemester(int id);
        
    }
}
