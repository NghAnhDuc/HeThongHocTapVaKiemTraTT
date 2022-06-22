using HeThongHocTapVaKiemTraTT.Data;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Class> GetClassByTeacher(int teacherId)
        {
            return _context.Classes.Where(p => p.Teacher.Id == teacherId).ToList();
        }

        public Teacher GetTeacher(int id)
        {
            return _context.Teachers.Where(p => p.Id == id).FirstOrDefault();
        }

        public Teacher GetATeacherFromAClass(int classId)
        {
            return _context.Classes.Where(p => p.Id == classId).Select(c => c.Teacher).FirstOrDefault();
        }

        public ICollection<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public bool CreateTeacher(Teacher teacher)
        {
            _context.Add(teacher);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            _context.Update(teacher);
            return Save();
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _context.Remove(teacher);
            return Save();
        }
    }
}
