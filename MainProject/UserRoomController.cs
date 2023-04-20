using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceInterfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoomController : ControllerBase
    {
        private readonly IUserRoomService _userRoomService;

        public UserRoomController(IUserRoomService userRoomService)
        {
            _userRoomService = userRoomService;
        }

        [HttpPost("JoinRoom/{roomId}")]
        public async Task<IActionResult> JoinRoom(int roomId)
        {
            try
            {
                await _userRoomService.JoinRoomAsync(roomId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("LeaveRoom/{roomId}")]
        public async Task<IActionResult> LeaveRoom(int roomId)
        {
            try
            {
                await _userRoomService.LeaveRoomAsync(roomId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveUser/{roomId}/{userId}")]
        public async Task<IActionResult> RemoveUser(int roomId, int userId)
        {
            try
            {
                await _userRoomService.DeleteByAdmin(roomId, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUsersByRoomId/{roomId}")]
        public async Task<ICollection<UserDto>> GetUsersByRoomId(int roomId)
        {
            try
            {
                return await _userRoomService.GetUsersByRoomId(roomId);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                return null;
            }
        }
    }
}
