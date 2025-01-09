using System.ComponentModel.DataAnnotations;
using Dtos.Hiring;
using Dtos.Hostel;

namespace Dtos.Bill
{
    public class BillDto
    {
        public int BillPaymentID { get; set; }
        public int AccountCreateID { get; set; }
        public int? HiringRoomHostelID { get; set; }
        public int? HostelID { get; set; }
        public int BillPaymentType { get; set; }
        public double BillPaymentAmount { get; set; }
        public string? BillNote { get; set; }
        public DateTime DateCreate { get; set; }
        public string? Status { get; set; }

        public IEnumerable<BillDetailDto>? Details { get; set; }
        public HiringDto? Hiring { get; set; }
        public HostelDto? Hostel { get; set; }

    }

    public class BillDetailDto
    {
        public int BillInformationID { get; set; }
        public int BillPaymentID { get; set; }
        public string? ServiceName { get; set; }
        public int? OldNumber { get; set; }
        public int? NewNumber { get; set; }
        public int? Number { get; set; }
        public double Amount { get; set; }
        public double FinalAmount { get; set; }
        public string? Note { get; set; }
    }

    public class NewBillDetailDto
    {
        [Required(ErrorMessage = "Vui lòng nhập dịch vụ !")]
        public string? ServiceName { get; set; }
        public int? OldNumber { get; set; }
        public int? NewNumber { get; set; }
        public int? Number { get; set; }
        public double Amount { get; set; }
        public double FinalAmount { get; set; }
        public string? Note { get; set; }
        public int ServiceRoomId { get; set; }
    }

    public class NewBillDto
    {
        public int HiringRoomHostelID { get; set; }
        public int HostelID { get; set; }
        public int BillPaymentType { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tổng tiền !")]
        public double BillPaymentAmount { get; set; }
        public string? BillNote { get; set; }
        public IEnumerable<NewBillDetailDto>? BillDetails { get; set; }
    }

    public class NewBillPayDto
    {
        public int HostelID { get; set; }
        public int BillPaymentType { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tổng tiền !")]
        public double BillPaymentAmount { get; set; }
        public string? BillNote { get; set; }
    }
}
