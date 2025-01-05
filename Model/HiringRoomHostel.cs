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
        public string? AccountHiringName { get; set; }
        public string? AccountHiringPhone { get; set; }
        public string? AccountHiringAddress { get; set; }
        public string? AccountHiringCitizen { get; set; }
        public int HiringType { get; set; }
        public double DepositAmount { get; set; }
        public int DateHiring {  get; set; }
        public DateTime? HiringStart { get; set; }
        public DateTime? HiringEnd {  get; set; }
        public DateTime DateCreate { get; set; }
        public string? Status { get; set; }

        public IList<HiringService>? HiringServices { get; set; }
        public IList<MemberHiringRoom>? MemberHiringRooms { get; set; }
        public IList<BillPayment>? BillPayments {  get; set; } 
    }
}
