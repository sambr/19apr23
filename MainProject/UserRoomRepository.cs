using DataModel.Interfaces;
using DataModel.Models;
using System;

namespace MainProject
{
    public class UserRoomRepository : IUserRoomRepository
    {
        private readonly List<UserRoomDto> _userRooms;
        private readonly List<UserDto> _users;

        public UserRoomRepository()
        {
            _userRooms = new List<UserRoomDto>();
            _users = new List<UserDto>();
        }

        public Task JoinRoom(UserRoomDto userRoom)
        {
            if (_userRooms.FirstOrDefault(x => x.RoomId == userRoom.RoomId) != null)
            { return Task.CompletedTask; }

            _userRooms.Add(userRoom);
            UserDto user = _users.FirstOrDefault(x => x.Id == userRoom.UserId);

            if (user == null)
            {
                user = new UserDto() { Id = userRoom.UserId, UserRooms = new List<UserRoomDto>() };
                user.UserRooms.Add(userRoom);
                _users.Add(user);
            }
            else
            {
                user.UserRooms.Add(userRoom);
            }

            return Task.CompletedTask;
        }

        public Task<ICollection<UserDto>> GetUsersByRoomId(int roomId)
        {
            var users = _users.Where(u => u.UserRooms.FirstOrDefault(ur => ur.RoomId == roomId) != null).ToList();
            return Task.FromResult<ICollection<UserDto>>(users);
        }

        public Task Delete(UserRoomDto userRoom)
        {
            var userR = GetUserRoomByRoomIdAnduserId(userRoom.RoomId, userRoom.UserId);
            if (userR != null)
            {
                _userRooms.Remove(userR);
            }
            return Task.CompletedTask;
        }

        public UserRoomDto GetUserRoomByRoomId(int roomId) 
        {
            return _userRooms.FirstOrDefault(x => x.RoomId == roomId);
        }

        public UserRoomDto GetUserRoomByRoomIdAnduserId(int roomId, int userId)
        {
            return _userRooms.FirstOrDefault(x => x.RoomId == roomId && x.UserId == userId);
        }
    }
}
