namespace Models
{
    public class HiringRoomHostel
    {
        public int HiringRoomHostelID { get; set; }
        public int AccountOwnerID { get; set; }
        public Account? AccountOwner { get; set; }
        public int HostelID { get; set; }
        public Hostel? Hostel { get; set; }
        public int? RoomID { get; set; }
        public Room? Room { get; set; }
        public int AccountHiringID { get; set; }
        public int HiringType { get; set; }
        public double DepositAmount { get; set; }
        public Account? AccountHiring { get; set; }
        public int DateHiring {  get; set; }
        public DateTime? HiringStart { get; set; }
        public DateTime HiringEnd {  get; set; }
        public DateTime DateCreate { get; set; }

        public IList<HiringService>? HiringServices { get; set; }
        public IList<HiringPayment>? HiringPayments { get; set; }
        public IList<MemberHiringRoom>? MemberHiringRooms { get; set; }
    }
}
