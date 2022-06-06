namespace HeThongHocTapVaKiemTraTT.Models
{
    public class AccountClass
    {
        public int AccountId { get; set; }
        public int ClassId { get; set; }
        public Account Account { get; set; }
        public Class Class { get; set; }
    }
}
