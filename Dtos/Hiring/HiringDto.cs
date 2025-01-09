using System.ComponentModel.DataAnnotations;
using Dtos.Hostel;
using Dtos.Room;
using Dtos.Service;

namespace Dtos.Hiring
{
    public class HiringDto
    {
        public int HiringRoomHostelID { get; set; }
        public int HostelID { get; set; }
        public HostelDto? Hostel { get; set; }
        public int? RoomID { get; set; }
        public RoomDto? Room { get; set; }
        public string? AccountHiringName { get; set; }
        public string? AccountHiringPhone { get; set; }
        public string? AccountHiringAddress { get; set; }
        public string? AccountHiringCitizen { get; set; }
        public int HiringType { get; set; }
        public double DepositAmount { get; set; }
        public DateTime? HiringStart { get; set; }
        public DateTime? HiringEnd { get; set; }
        public DateTime DateCreate { get; set; }
        public string? Status { get; set; }
    }

    public class CreateHiringDto
    {
        public int HostelID { get; set; }
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên người thuê !")]
        public string? AccountHiringName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại !")]
        public string? AccountHiringPhone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ thường trú !")]
        public string? AccountHiringAddress { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số căn cước !")]
        public string? AccountHiringCitizen { get; set; }
        public int HiringType { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tiền cọc !")]
        public double DepositAmount { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu !")]
        public DateTime? HiringStart { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày kết thúc !")]
        public DateTime? HiringEnd { get; set; }
        public IEnumerable<NewRoomServiceDto>? ServiceRooms { get; set; }
    }


    public class HiringMemberDto
    {
        public int MemberHiringID { get; set; }
        public int HiringRoomHostelID { get; set; }
        public string? MemberHiringName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? CitizenCard { get; set; }
        public int? Gender { get; set; }
    }

    public class NewHiringMemberDto
    {
        public int HiringRoomHostelID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên người thuê !")]
        public string? MemberHiringName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thường trú!")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại !")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập căn cước !")]
        public string? CitizenCard { get; set; }
    }

    public class HiringInformationDto
    {
        public HiringDto? HiringInformation { get; set; }
        public IEnumerable<HiringMemberDto>? Members { get; set; }
        public IEnumerable<RoomServiceInformationDto>? ServiceRooms { get; set; }
    }

    public class NewServiceLogIndexDto
    {
        public int ServiceRoomID { get; set; }
        public int ServiceHostelID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chỉ số !")]
        public int? ServiceLog { get; set; }
    }
}
