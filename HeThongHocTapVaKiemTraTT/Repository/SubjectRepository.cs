using HeThongHocTapVaKiemTraTT.Data;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DataContext _context;

        public SubjectRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSubject(Subject subject)
        {
            _context.Add(subject);
            return Save();
        }

        public bool DeleteSubject(Subject subject)
        {
            _context.Remove(subject);
            return Save();
        }

        public ICollection<Class> GetClassBySubject(int subjectId)
        {
            return _context.Classes.Where(p => p.Subject.Id == subjectId).ToList();
        }

        public Subject GetSubject(int id)
        {
            return _context.Subjects.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Subject> GetSubjects()
        {
            return _context.Subjects.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateSubject(Subject subject)
        {
            _context.Update(subject);
            return Save();
        }
    }
}
