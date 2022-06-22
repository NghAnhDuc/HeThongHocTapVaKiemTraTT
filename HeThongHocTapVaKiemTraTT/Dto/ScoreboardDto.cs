using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Dto
{
    public class ScoreboardDto
    {
        public int Id { get; set; }
        public double AttendanceScore { get; set; }
        public double OralScore { get; set; }
        public double Score15Minutes { get; set; }
        public double ScoreCoefficient2 { get; set; }
        public double ScoreCoefficient3 { get; set; }
        public double AverageScore { get; set; }
        public double TotalAverageScore { get; set; }
        public string Result { get; set; }
        public DateTime UpdateDate { get; set; }
       
    }
}
