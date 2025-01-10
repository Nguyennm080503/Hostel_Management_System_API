using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : BaseApiController
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        [HttpGet("customer/payment")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetCustomerDashboardPayment(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                int accountId = GetLoginAccountId();
                var dashboard = await dashboardService.GetCustomerDashboardPayment(accountId, dateStart, dateEnd);
                return Ok(dashboard);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("customer/payment/month")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetCustomerDashboardPaymentEachMonth(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                int accountId = GetLoginAccountId();
                var dashboard = await dashboardService.GetCustomerDashboardPaymentEachMonth(accountId, dateStart, dateEnd);
                return Ok(dashboard);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("customer/total")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetCustomerDashboardCount(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                int accountId = GetLoginAccountId();
                var dashboard = await dashboardService.GetCustomerTotalStatistic(accountId, dateStart, dateEnd);
                return Ok(dashboard);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
