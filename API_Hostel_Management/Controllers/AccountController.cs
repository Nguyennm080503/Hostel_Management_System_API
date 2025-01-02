using Azure.Messaging;
using Dtos.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("all")]
        [Authorize(policy: "Admin")]
        public async Task<ActionResult> GetCustomerAccounts()
        {
            try
            {
                var accounts = await _accountService.GetAllAccountInFlatform();
                return Ok(accounts);
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

        [HttpPost("add/employees")]
        [Authorize(policy: "Admin")]
        public async Task<ActionResult> CreateEmployeeAccount([FromBody] NewEmployeeAccountDto newStaffAndManagerAccountDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _accountService.CreateAccountStaff(newStaffAndManagerAccountDto);
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

        [HttpPost("auth/login")]
        public async Task<ActionResult<LoginAccountDto>> LoginUsername(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                var user = await _accountService.LoginSystem(loginDto);

                if (user == null)
                {
                    return Unauthorized("Sai mật khẩu");
                }
                return Ok(user);
            }
            catch (ServiceException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{accountId}/status")]
        [Authorize(policy: "Admin")]
        public async Task<IActionResult> ChangeAccountStatus(int accountId, [FromQuery, BindRequired] string status)
        {
            try
            {
                var result = await _accountService.ChangeAccountStatus(accountId, status);
                if (result) return Ok("Đổi trạng thái tài khoản thành công!");
                return BadRequest("Đổi trạng thái tài khoản thất bại!");
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
