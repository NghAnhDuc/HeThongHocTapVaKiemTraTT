using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface IScheduleRepository
    {
        ICollection<Schedule> GetSchedules();
        Schedule GetSchedule(int id);
    }
}
