using DataModel.Models;
using System.Threading.Tasks;

namespace Services.ServiceInterfaces;

public interface IUserRoomService
{
    Task JoinRoomAsync(int roomId);
    Task LeaveRoomAsync(int roomId);
    Task DeleteByAdmin(int roomId, int userId);
    Task<ICollection<UserDto>> GetUsersByRoomId(int roomId);
}