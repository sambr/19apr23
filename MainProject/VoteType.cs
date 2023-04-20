using System.Text.Json.Serialization;

namespace Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VoteType
{
    Integer,
    Fibonacci,
    Tshirt
}