using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DentistryManagement.Server.Helpers
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserProvider(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string GetUserId()
        {
            return _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
