using System.ComponentModel.DataAnnotations;

namespace Dtos.Measurement
{
    public class MeasurementDto
    {
        public int MeasurementID { get; set; }
        public string? MeasurementName { get; set; }
        public string? MeasurementDescription { get; set; }
        public int MeasurementType { get; set; }
    }

    public class NewMeasurementDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đơn vị đo lường !")]
        public string? MeasurementName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung !")]
        public string? MeasurementDescription { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại đo lường !")]
        public int MeasurementType { get; set; }
    }
}
