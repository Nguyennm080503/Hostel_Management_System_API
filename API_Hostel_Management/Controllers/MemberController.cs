using Dtos.Hiring;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : BaseApiController
    {
        private readonly IMemberHiringService _memberHiringService;

        public MemberController(IMemberHiringService memberHiringService)
        {
            _memberHiringService = memberHiringService;
        }

        [HttpPost("add/member")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> CreateMember([FromBody] NewHiringMemberDto memberDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                int accountId = GetLoginAccountId();
                await _memberHiringService.CreateMember(memberDto);
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
