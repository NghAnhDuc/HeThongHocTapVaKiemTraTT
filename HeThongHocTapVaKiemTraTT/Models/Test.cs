namespace HeThongHocTapVaKiemTraTT.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public string Questions { get; set; }
        public double Score { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Schedule Schedule { get; set; }
        public Account Account { get; set; }
    }
}
