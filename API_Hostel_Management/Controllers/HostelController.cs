﻿using Dtos.Hostel;
using Dtos.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Exception;
using Service.Implement;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/hostels/customer")]
    [ApiController]
    public class HostelController : BaseApiController
    {
        private readonly IHostelService _hostelService;

        public HostelController(IHostelService hostelService)
        {
            _hostelService = hostelService;
        }

        [HttpGet("all")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetAllHostelOfCustomer()
        {
            try
            {
                int accountId = GetLoginAccountId();
                var hostels = await _hostelService.GetAllHostelOfCustomer(accountId);
                return Ok(hostels);
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

        [HttpPost("add/hostel")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> CreateHostel([FromBody] NewHostelDto hostelDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                int accountId = GetLoginAccountId();
                await _hostelService.AddNewHostel(hostelDto, accountId);
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

        [HttpPatch("update/hostel")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> UpdateHostel([FromBody] UpdateHostelDto hostelDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                int accountId = GetLoginAccountId();
                await _hostelService.UpdateHostel(hostelDto, accountId);
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

        [HttpDelete("delete/hostel")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> DeleteHostel(int hostelId)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _hostelService.DeleteHostel(hostelId);
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
