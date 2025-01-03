using Dtos.Hostel;
using Dtos.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Exception;
using Service.Interface;

namespace API_Hostel_Management.Controllers
{
    [Route("api/hostels/rooms")]
    [ApiController]
    public class RoomController : BaseApiController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("all")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> GetAllRoomOfHostel(int hostelId)
        {
            try
            {
                var rooms = await _roomService.GetAllRoomsOfHostel(hostelId);
                return Ok(rooms);
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

        [HttpPost("add/room")]
        [Authorize(policy: "Customer")]
        public async Task<ActionResult> CreateRoom([FromBody] NewRoomDto roomDto)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = ModelStateValidation.GetValidationErrors(ModelState);
                return BadRequest(errorMessages);
            }

            try
            {
                await _roomService.AddNewRoom(roomDto);
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
