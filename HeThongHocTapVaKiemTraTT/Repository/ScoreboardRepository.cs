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
        public Scoreboard GetScoreboard(int id)
        {
            return _context.Scoreboards.Where(P => P.Id == id).FirstOrDefault();
        }

        public ICollection<Scoreboard> GetScoreboards()
        {
            return _context.Scoreboards.OrderBy(P => P.Id).ToList();
        }
    }
}
