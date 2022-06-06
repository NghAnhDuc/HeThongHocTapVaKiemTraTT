namespace HeThongHocTapVaKiemTraTT.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public ICollection<Scoreboard> Scoreboards { get; set; }
        public ICollection<AccountClass> AccountClasses { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
