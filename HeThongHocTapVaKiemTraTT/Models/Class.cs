namespace HeThongHocTapVaKiemTraTT.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Describe { get; set; }
        public int NumberOfSessions { get; set; }
        public string Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SecurityCode { get; set; }
        public string Link { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Semester Semester { get; set; }
        public Schedule Schedule { get; set; }
        public ICollection<AccountClass> AccountClasses { get; set; }
    }
}
