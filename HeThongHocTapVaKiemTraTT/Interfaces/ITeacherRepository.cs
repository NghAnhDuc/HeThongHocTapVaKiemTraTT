using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface ITeacherRepository
    {
        ICollection<Teacher> GetTeachers();
        Teacher GetTeacher(int id);
        Teacher GetATeacherFromAClass(int classId);
        ICollection<Class> GetClassByTeacher(int teacherId);
    }
}
