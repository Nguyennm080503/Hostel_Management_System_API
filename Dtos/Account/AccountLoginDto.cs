using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Account
{
    public class LoginAccountDto
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
        public string? Token { get; set; }
    }

    public class LoginDto
    {
        [Required(ErrorMessage = "Vui lòng nhập email đăng nhập!")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng format email đăng nhập!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập mật khẩu đăng nhập!")]
        public string Password { get; set; }

    }
}
