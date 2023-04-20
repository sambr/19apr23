using System.Collections.Generic;

namespace MainProject.Models;

public class RoomDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? CreatedBy { get; set; }
    public int? CurrentStoryId { get; set; }

    public ICollection<UserRoomDto> RoomUsers { get; set; }
    public UserDto User { get; set; }
    public ICollection<StoryDto> Stories { get; set; }
}