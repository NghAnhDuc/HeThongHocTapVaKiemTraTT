namespace HeThongHocTapVaKiemTraTT.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
