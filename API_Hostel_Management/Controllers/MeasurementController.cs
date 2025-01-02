using Dtos.Measurement;
using Dtos.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/measurements")]
    [ApiController]
    public class MeasurementController : BaseApiController
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
           _measurementService = measurementService;
        }

        [HttpGet("all")]
        [Authorize(policy: "Admin")]
        public async Task<ActionResult> GetAllMeasurements()
        {
            try
            {
                var measurements = await _measurementService.GetAllMeasureInFlatfrom();
                return Ok(measurements);
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

        [HttpPost("add/measurement")]
        [Authorize(policy: "Admin")]
        public async Task<ActionResult> CreateMeasurement([FromBody] NewMeasurementDto newMeasurementDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _measurementService.AddNewMeasurement(newMeasurementDto);
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

        [HttpDelete("delete/measurement")]
        [Authorize(policy: "Admin")]
        public async Task<ActionResult> DeleteMeasurement(int measurementID)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _measurementService.DeleteMeasurement(measurementID);
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
