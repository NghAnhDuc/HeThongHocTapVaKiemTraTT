using HeThongHocTapVaKiemTraTT.Data;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext _context;

        public ScheduleRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSchedule(Schedule schedule)
        {
            _context.Add(schedule);
            return Save();
        }

        public bool DeleteSchedule(Schedule schedule)
        {
            _context.Remove(schedule);
            return Save();
        }

        public Schedule GetSchedule(int id)
        {
            return _context.Schedules.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Schedule> GetSchedules()
        {
            return _context.Schedules.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateSchedule(Schedule schedule)
        {
            _context.Update(schedule);
            return Save();
        }
    }
}
