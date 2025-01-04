namespace Models
{
    public class ServiceHostelRoom
    {
        public int ServiceHostelID { get; set; }
        public int AccountID { get; set; }
        public Account Account { get; set; }
        public string? ServiceHostelName { get; set; }
        public int ServiceHostelPrice { get; set; }
        public int MeasurementID { get; set; }
        public string? Status { get; set; }
        public DateTime DateCreate { get; set; }

        public Measurement? Measurement { get; set; }
        public IList<HiringService>? HiringServices { get; set; }
        public IList<ServiceHostel>? ServiceHostels { get; set; }
    }
}
