using System.Collections.Generic;

namespace MainProject.Models;

public class UserDto
{
    public int Id { get; set; }
    public string EmailAddress { get; set; }
    public ICollection<UserRoomDto> UserRooms { get; set; }
    public VoteDto Vote { get; set; }
}