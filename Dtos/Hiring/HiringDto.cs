using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Hostel;
using Dtos.Room;

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
        public string? AccountHiringName { get; set; }
        public string? AccountHiringPhone { get; set; }
        public string? AccountHiringAddress { get; set; }
        public string? AccountHiringCitizen { get; set; }
        public int HiringType { get; set; }
        public double DepositAmount { get; set; }
        public DateTime? HiringStart { get; set; }
        public DateTime? HiringEnd { get; set; }
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
        public string? MemberHiringName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? CitizenCard { get; set; }
    }

    public class HiringInformationDto
    {
        public HiringDto? HiringInformation { get; set; }
        public IEnumerable<HiringMemberDto>? Members { get; set; }
    }
}
