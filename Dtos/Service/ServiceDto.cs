using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
