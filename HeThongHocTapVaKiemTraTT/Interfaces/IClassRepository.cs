using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface IClassRepository
    {
        ICollection<Class> GetClasses();
        Class GetClass(int id);
        bool CreateClass(Class classs);
        bool UpdateClass(int subjectId, int teacherId, int semesterId, int scheduleId, Class classs);
        bool DeleteClass(Class classs);
        bool Save();
    }
}
