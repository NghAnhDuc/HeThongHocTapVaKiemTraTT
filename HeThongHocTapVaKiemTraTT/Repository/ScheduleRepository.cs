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
        public Schedule GetSchedule(int id)
        {
            return _context.Schedules.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Schedule> GetSchedules()
        {
            return _context.Schedules.OrderBy(p => p.Id).ToList();
        }
    }
}
