using System.ComponentModel.DataAnnotations;

namespace Dtos.Hostel
{
    public class HostelDto
    {
        public int HostelID { get; set; }
        public string? HostelName { get; set; }
        public int HostelType { get; set; }
        public string? HostelAddress { get; set; }
        public int HostelRooms { get; set; }
        public string? Status { get; set; }
    }

    public class NewHostelDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên nhà !")]
        public string? HostelName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại nhà thuê !")]
        public int HostelType { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhà !")]
        public string? HostelAddress { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số phòng của nhà !")]
        public int HostelRooms { get; set; }
    }
}
