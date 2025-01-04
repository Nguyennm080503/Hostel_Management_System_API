namespace Models
{
    public class MemberHiringRoom
    {
        public int MemberHiringID { get; set; }
        public int HiringRoomHostelID { get; set; }
        public HiringRoomHostel? HiringRoomHostel { get; set; }
        public string? MemberHiringName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? CitizenCard { get; set; }
        public int? Gender { get; set; }
    }
}
