using System.Collections.Generic;
using System.Threading.Tasks;
using MainProject.Models;

namespace MainProject.Interfaces;

public interface IUserRoomRepository
{
    Task JoinRoom(UserRoomDto userRoom);
    Task<ICollection<UserDto>> GetUsersByRoomId(int roomId);
    Task Delete(UserRoomDto userRoom);
}