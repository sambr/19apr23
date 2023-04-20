using System.Text.Json.Serialization;

namespace Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StoryState
{
    VotingNotStarted,
    VotingInProgress,
    VotingFinished,
    Done
}