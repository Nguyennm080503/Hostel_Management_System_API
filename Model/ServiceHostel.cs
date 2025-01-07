namespace Models
{
    public class ServiceHostel
    {
        public int HiringServiceHostelID { get; set; }
        public int HostelID { get; set; }
        public Hostel? Hostel { get; set; }
        public int ServiceHostelRoomID { get; set; }
        public ServiceHostelRoom? ServiceHostelRoom { get; set; }

        public IList<ServiceLogIndex>? ServiceLogIndices { get; set; }
    }
}
