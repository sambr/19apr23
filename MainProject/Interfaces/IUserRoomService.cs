using MainProject.Models;
using System.Threading.Tasks;

namespace MainProject.Interfaces;

public interface IUserRoomService
{
    Task JoinRoomAsync(int roomId);
    Task LeaveRoomAsync(int roomId);
    Task DeleteByAdmin(int roomId, int userId);
    Task<ICollection<UserDto>> GetUsersByRoomId(int roomId);
}