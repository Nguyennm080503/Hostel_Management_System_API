namespace Models
{
    public class ServiceLogIndex
    {
        public int ServiceLogIndexID { get; set; }
        public int? ServiceRoomID { get; set; }
        public HiringService? ServiceRoom { get; set; }
        public int? ServiceHostelID { get; set; }
        public ServiceHostel? ServiceHostel { get; set; }
        public int ServiceLog {  get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
