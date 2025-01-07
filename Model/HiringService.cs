namespace Models
{
    public class HiringService
    {
        public int HiringServiceID { get; set; }
        public int HiringRoomHostelID { get; set; }
        public HiringRoomHostel? HiringRoomHostel { get; set; }
        public int ServiceHostelRoomID { get; set; }
        public ServiceHostelRoom? ServiceHostelRoom { get; set; }

        public IList<ServiceLogIndex>? ServiceLogIndices { get; set; }

    }
}
