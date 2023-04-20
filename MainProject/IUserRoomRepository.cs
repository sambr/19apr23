using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace DataModel.Interfaces;

public interface IUserRoomRepository
{
    Task JoinRoom(UserRoomDto userRoom);
    Task<ICollection<UserDto>> GetUsersByRoomId(int roomId);
    Task Delete(UserRoomDto userRoom);
}