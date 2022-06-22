using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Interfaces
{
    public interface IScoreboardRepository
    {
        ICollection<Scoreboard> GetScoreboards();
        Scoreboard GetScoreboard(int id);
        bool CreateScoreboard(Scoreboard scoreboard);
        bool UpdateScoreboard(Scoreboard scoreboard);
        bool DeleteScoreboard(Scoreboard scoreboard);
        bool Save();
    }
}
