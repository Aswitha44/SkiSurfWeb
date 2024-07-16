using System.Security.Claims;

namespace SkiSurf.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string RetireveEmailFromPrincipal(this ClaimsPrincipal user) {
            return user.FindFirstValue(ClaimTypes.Email);

        }
    }
}
