using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface IScheduleRepository
    {
        ICollection<Schedule> GetSchedules();
        Schedule GetSchedule(int id);
        bool CreateSchedule(Schedule schedule);
        bool UpdateSchedule(Schedule schedule);
        bool DeleteSchedule(Schedule schedule);
        bool Save();
    }
}
