using HeThongHocTapVaKiemTraTT.Data;
using HeThongHocTapVaKiemTraTT.Interfaces;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Repository
{
    public class ScoreboardRepository : IScoreboardRepository
    {
        private readonly DataContext _context;

        public ScoreboardRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateScoreboard(Scoreboard scoreboard)
        {
            _context.Add(scoreboard);
            return Save();
        }

        public bool DeleteScoreboard(Scoreboard scoreboard)
        {
            _context.Remove(scoreboard);
            return Save();
        }

        public Scoreboard GetScoreboard(int id)
        {
            return _context.Scoreboards.Where(P => P.Id == id).FirstOrDefault();
        }

        public ICollection<Scoreboard> GetScoreboards()
        {
            return _context.Scoreboards.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateScoreboard(Scoreboard scoreboard)
        {
            _context.Update(scoreboard);
            return Save();
        }
    }
}
