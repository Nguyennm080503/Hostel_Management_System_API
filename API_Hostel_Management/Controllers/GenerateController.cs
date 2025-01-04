using Dtos.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/generate")]
    [ApiController]
    public class GenerateController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public GenerateController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("account")]
        [Authorize(policy: "Admin")]
        public async Task<ActionResult> CreateAccount([FromBody] AccountNumberDto numberAccount)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _accountService.CreateAccountSample(numberAccount.Number);
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
    }
}
