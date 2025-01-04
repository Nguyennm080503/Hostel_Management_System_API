using Dtos.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/services/hostel")]
    [ApiController]
    public class ServiceHostelController : BaseApiController
    {
        private readonly IServiceHostelService _service;

        public ServiceHostelController(IServiceHostelService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetAllServices(int hostelId)
        {
            try
            {
                var services = await _service.GetAllServiceOfCustomer(hostelId);
                return Ok(services);
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

        [HttpPost("add/service")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> CreateService([FromBody] IEnumerable<NewHostelServiceDto> newService)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _service.AddNewService(newService);
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
