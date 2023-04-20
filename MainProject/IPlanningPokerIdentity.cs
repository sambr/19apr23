using System.Security.Claims;

namespace Services.ServiceInterfaces;

public interface IPlanningPokerIdentity
{
    int LoggedInUserId { get; }
    ClaimsPrincipal User { get; }
}