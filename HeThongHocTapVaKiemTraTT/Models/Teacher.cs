namespace HeThongHocTapVaKiemTraTT.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
