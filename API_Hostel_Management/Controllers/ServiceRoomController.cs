using Dtos.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/services/customer")]
    [ApiController]
    public class ServiceRoomController : BaseApiController
    {
        private readonly IServiceRoomService _serviceRoomService;

        public ServiceRoomController(IServiceRoomService serviceRoomService)
        {
            _serviceRoomService = serviceRoomService;
        }

        [HttpGet("all")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetAllServices()
        {
            try
            {
                int accountID = GetLoginAccountId();
                var services = await _serviceRoomService.GetAllServiceOfCustomer(accountID);
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
        public async Task<ActionResult> CreateService([FromBody] NewServiceRoomDto newService)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                int accountID = GetLoginAccountId();
                await _serviceRoomService.AddNewService(newService, accountID);
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

        [HttpDelete("delete/service")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> DeleteService(int serviceID)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _serviceRoomService.DeleteService(serviceID);
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

        [HttpPatch("update/service")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> UpdateService(UpdateServiceHiringDto updateService)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _serviceRoomService.UpdateService(updateService);
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
