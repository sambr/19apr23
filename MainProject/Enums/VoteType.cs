using System.Text.Json.Serialization;

namespace MainProject.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VoteType
{
    Integer,
    Fibonacci,
    Tshirt
}