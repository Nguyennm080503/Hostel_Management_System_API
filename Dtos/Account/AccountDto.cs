using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Account
{
    public class AccountDto
    {
        public int AccountID { get; set; }
        public int? Role { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? CitizenCard { get; set; }
        public int? Gender { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
    }

    public class AccountBaseDto
    {
        public int AccountID { get; set; }
        public int? Role { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? CitizenCard { get; set; }
        public int? Gender { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
    }

    public class NewBaseAccountDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên !")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email !")]
        [EmailAddress(ErrorMessage = "Format email không đúng !")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại !")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giới tính !")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ !")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập căn cước công dân !")]
        public string? CitizenCard { get; set; }
    }

    public class NewEmployeeAccountDto : NewBaseAccountDto 
    {

    }

    public class AccountNumberDto
    {
        public int Number { get; set; }
    }
}
