using Dtos.Bill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/bill")]
    [ApiController]
    public class BillPaymentController : BaseApiController
    {
        private readonly IBillPaymentService billPaymentService;

        public BillPaymentController(IBillPaymentService billPaymentService)
        {
            this.billPaymentService = billPaymentService;
        }


        [HttpPost("add/bill")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> CreateBill([FromBody] NewBillDto billDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                int accountId = GetLoginAccountId();
                await billPaymentService.CreateNewBillPayment(billDto, accountId);
                return Ok();
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

        [HttpPost("add/bill-pay")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> CreateBillPay([FromBody] NewBillPayDto billDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                int accountId = GetLoginAccountId();
                await billPaymentService.CreateNewBillPaymentSpending(billDto, accountId);
                return Ok();
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

        [HttpGet("hiring/history/all")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetPaymentHistory(int hiringId)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                var bills = await billPaymentService.GetPaymentHistory(hiringId);
                return Ok(bills);
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

        [HttpGet("hiring/history/detail")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetPaymentDetail(int paymentId)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                var bill = await billPaymentService.GetPaymentDetail(paymentId);
                return Ok(bill);
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

        [HttpGet("all")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetPaymentsByAccount()
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                int accountId = GetLoginAccountId();
                var bills = await billPaymentService.GetBillsByAccount(accountId);
                return Ok(bills);
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
