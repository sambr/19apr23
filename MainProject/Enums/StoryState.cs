using System.Text.Json.Serialization;

namespace MainProject.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StoryState
{
    VotingNotStarted,
    VotingInProgress,
    VotingFinished,
    Done
}