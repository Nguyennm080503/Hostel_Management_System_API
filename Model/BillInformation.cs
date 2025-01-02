namespace Models
{
    public class BillInformation
    {
        public int BillInformationID { get; set; }
        public int BillPaymentID { get; set; }
        public BillPayment? BillPayment { get; set; }
        public string? ServiceName {  get; set; }
        public int? OldNumber { get; set; }
        public int? NewNumber { get; set; }
        public int? Number {  get; set; }
        public double  Amount {  get; set; }
        public double FinalAmount { get; set; }
        public string? Note { get; set; }
    }
}
