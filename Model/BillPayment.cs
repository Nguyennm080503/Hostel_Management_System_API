namespace Models
{
    public class BillPayment
    {
        public int BillPaymentID { get; set; }
        public int AccountCreateID { get; set; }
        public Account? AccountCreate { get; set; }
        public int? HiringRoomHostelID { get; set; }
        public HiringRoomHostel? HiringRoomHostel { get; set; }
        public int? HostelID { get; set; }
        public Hostel? Hostel { get; set; }
        public int BillPaymentType { get; set; }
        public double BillPaymentAmount { get; set; }
        public string? BillNote { get; set; }
        public DateTime DateCreate { get; set; }
        public string? Status { get; set; }

        public IList<BillInformation>? BillInformation { get; set; }
    }
}
