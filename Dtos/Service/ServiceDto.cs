using System.ComponentModel.DataAnnotations;
using Dtos.Measurement;

namespace Dtos.Service
{
    public class ServiceDto
    {
        public int ServiceID { get; set; }
        public string? ServiceName { get; set; }
    }

    public class NewServiceDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên dịch vụ !")]
        public string? ServiceName { get; set; }
    }

    public class ServiceRoomDto
    {
        public int ServiceHostelID { get; set; }
        public int AccountID { get; set; }
        public string? ServiceHostelName { get; set; }
        public int ServiceHostelPrice { get; set; }
        public int MeasurementID { get; set; }
        public MeasurementDto Measurement { get; set; }
    }

    public class NewServiceRoomDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên dịch vụ !")]
        public string? ServiceHostelName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá dịch vụ !")]
        public int ServiceHostelPrice { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại dịch vụ !")]
        public int MeasurementID { get; set; }
    }

    public class HostelServiceDto
    {
        public int HiringServiceHostelID { get; set; }
        public int HostelID { get; set; }
        public int ServiceHostelRoomID { get; set; }
        public ServiceRoomDto ServiceHostel { get; set; }
    }

    public class NewHostelServiceDto
    {
        public int HostelID { get; set; }
        public int ServiceHostelRoomID { get; set; }
    }

    public class UpdateServiceHiringDto
    {
        public int ServiceHostelID { get; set; }
        public int ServiceHostelPrice { get; set; }
    }
}
