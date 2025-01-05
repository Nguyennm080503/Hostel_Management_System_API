namespace Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public int? Role { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? CitizenCard { get; set; }
        public int? Gender { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? OtpToken { get; set; }
        public string? Status { get; set; }

        public IList<Hostel>? Hostels { get; set; }
        public IList<HiringRoomHostel>? HiringRoomOwner {  get; set; }
        public IList<ServiceHostelRoom>? ServiceHostelRooms { get; set; }
    }
}
