using System.Security.Claims;

namespace MainProject.Interfaces;

public interface IPlanningPokerIdentity
{
    int LoggedInUserId { get; }
    ClaimsPrincipal User { get; }
}