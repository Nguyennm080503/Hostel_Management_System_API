namespace Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int HostelID { get; set; }
        public Hostel? Hostel { get; set; }
        public string? RoomName { get; set; }
        public int? Capacity { get; set; }
        public double? Lenght { get; set; }
        public double? Width { get; set; }
        public double? Area { get; set; }
        public double? RoomFee { get; set; }
        public string? Status { get; set; }
        public DateTime? DateCreate { get; set; }

        public IList<HiringRoomHostel>? HiringRoomHostels { get; set; }
    }
}
