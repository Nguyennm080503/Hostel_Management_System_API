using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos.Hostel;

namespace Dtos.Dashboard
{
    public class DashboardDto
    {
        public int CountHostelCustomer {  get; set; }
        public int CountTotalSpending { get; set; }
        public int CountTotalReceive { get; set; }
        public int CountService {  get; set; }
    }

    public class DashboardPaymentDto
    {
        public int HostelID { get; set; }
        public HostelDto? Hostel { get; set; }
        public int CountTotalSpending { get; set; }
        public int CountTotalReceive { get; set; }
    }

    public class DashboardPaymentMonthDto
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int CountTotalSpending { get; set; }
        public int CountTotalReceive { get; set; }
    }
}
