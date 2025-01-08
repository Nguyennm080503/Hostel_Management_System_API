namespace Models
{
    public class Hostel
    {
        public int HostelID { get; set; }
        public int? AccountID { get; set; }
        public string? HostelName { get; set; }
        public int HostelType { get; set; }
        public string? HostelAddress { get; set; }
        public int HostelRooms { get; set; }
        public string? Status { get; set; }

        public Account? AccountOwner { get; set; }
        public IList<Room>? Rooms { get; set; }
        public IList<ServiceHostel>? ServiceHostels { get; set; }
        public IList<BillPayment>? BillPayments { get; set; }
    }
}
