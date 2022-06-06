namespace HeThongHocTapVaKiemTraTT.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}
