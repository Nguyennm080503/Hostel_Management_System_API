using System.ComponentModel.DataAnnotations;
using Dtos.Hostel;

namespace Dtos.Room
{
    public class RoomDto
    {
        public int RoomID { get; set; }
        public int HostelID { get; set; }
        public string? RoomName { get; set; }
        public int? Capacity { get; set; }
        public double? Lenght { get; set; }
        public double? Width { get; set; }
        public double? Area { get; set; }
        public double? RoomFee { get; set; }
        public string? Status { get; set; }
    }

    public class HostelRoomDto
    {
        public IEnumerable<RoomDto> Rooms { get; set; }
        public HostelDto Hostel { get; set; }
    }

    public class NewRoomDto
    {
        public int HostelID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên phòng !")]
        public string? RoomName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tối đa người ở !")]
        public int? Capacity { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập chiều dài phòng !")]
        public double? Lenght { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập chiều rộng phòng !")]
        public double? Width { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số tiền thuê phòng này !")]
        public double? RoomFee { get; set; }
        public double? Area { get; set; }
    }

    public class UpdateRoomDto
    {
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên phòng !")]
        public string? RoomName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tối đa người ở !")]
        public int? Capacity { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số tiền thuê phòng này !")]
        public double? RoomFee { get; set; }
    }
}
