using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Services.ServiceInterfaces;

namespace Services;

public class PlanningPokerIdentity : IPlanningPokerIdentity
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private string _random_user;

    public PlanningPokerIdentity(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _random_user = new Random().Next(1, 100).ToString();
    }

    public int LoggedInUserId => int.Parse(GetCurrentUserId());
    public ClaimsPrincipal User
    {
        get {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null)
            {
                return new ClaimsPrincipal(
                        new ClaimsIdentity(
                            new Claim[] { new Claim("userId", _random_user) },
                            "Basic")
                        );
            }
            
            return _httpContextAccessor.HttpContext.User; 
        }
    }
    
    private string GetCurrentUserId()
    {
        if (User.Claims.Count() > 0)
        {
            return User.Claims.Single(x => x.Type == "userId").Value;
        }
        else
        {
            return _random_user;
        }
    }
}