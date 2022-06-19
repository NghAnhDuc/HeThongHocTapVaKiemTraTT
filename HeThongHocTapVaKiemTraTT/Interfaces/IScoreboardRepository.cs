using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface IScoreboardRepository
    {
        ICollection<Scoreboard> GetScoreboards();
        Scoreboard GetScoreboard(int id);

    }
}
