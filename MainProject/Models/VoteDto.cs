namespace MainProject.Models;

public class VoteDto
{
    public int Id { get; set; }
    public string Value { get; set; }
    public int StoryId { get; set; }
    public int UserId { get; set; }
    public bool Status { get; set; }
    public UserDto User { get; set; }
    public StoryDto Story { get; set; }
}