using Dtos.Hiring;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/hiring")]
    [ApiController]
    public class HiringHostelController : BaseApiController
    {
        private readonly IHiringHostelService _hiringHostel;

        public HiringHostelController(IHiringHostelService hiringHostel)
        {
            _hiringHostel = hiringHostel;
        }

        [HttpGet("current")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetHiringCurrent(int roomId)
        {
            try
            {
                var hiring = await _hiringHostel.GetHiringCurrent(roomId);
                return Ok(hiring);
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

        [HttpPost("add/hiring")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> CreateHiring([FromBody] CreateHiringDto hiringDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                int accountId = GetLoginAccountId();
                await _hiringHostel.CreateHiringHostel(hiringDto, accountId);
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

        [HttpGet("history")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetHistoryHiringOfRoom(int roomId)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _hiringHostel.GetAllHiringsHistory(roomId);
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
