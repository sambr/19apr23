using System.Collections.Generic;
using Common.Enums;

namespace DataModel.Models;

public class StoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public StoryState StoryState { get; set; }
    public VoteType VoteType { get; set; }
    public string FinalScore { get; set; }
    public int RoomId { get; set; }
    public RoomDto Room { get; set; }
    public ICollection<VoteDto> Votes { get; set; }
}