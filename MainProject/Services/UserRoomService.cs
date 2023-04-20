using System.Threading.Tasks;
using MainProject.Interfaces;
using MainProject.Models;

namespace MainProject.Services;

public class UserRoomService : IUserRoomService
{
    private readonly IUserRoomRepository _userRoomRepository;
    private readonly IPlanningPokerIdentity _identity;

    public UserRoomService(
        IUserRoomRepository userRoomRepository,
        IPlanningPokerIdentity identity)
    {
        _userRoomRepository = userRoomRepository;
        _identity = identity;
    }

    public async Task JoinRoomAsync(int roomId)
    {
        var userRoomDto = new UserRoomDto
        {
            RoomId = roomId,
            UserId = _identity.LoggedInUserId
        };

        await _userRoomRepository.JoinRoom(userRoomDto);
    }

    public async Task LeaveRoomAsync(int roomId)
    {
        var itemToDelete = new UserRoomDto
        {
            RoomId = roomId,
            UserId = _identity.LoggedInUserId
        };

        await _userRoomRepository.Delete(itemToDelete);
    }

    public async Task DeleteByAdmin(int roomId, int userId)
    {
        var itemToDelete = new UserRoomDto
        {
            RoomId = roomId,
            UserId = userId
        };

        await _userRoomRepository.Delete(itemToDelete);
    }

    public async Task<ICollection<UserDto>> GetUsersByRoomId(int roomId)
    {
        return await _userRoomRepository.GetUsersByRoomId(roomId);
    }

}