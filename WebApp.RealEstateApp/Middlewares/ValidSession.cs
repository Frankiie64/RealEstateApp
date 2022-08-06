using Microsoft.AspNetCore.Http;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;

namespace WebApp.RealEstateApp.middlewares
{
    public class ValidSession
    {
        private readonly IHttpContextAccessor _context;

        public ValidSession(IHttpContextAccessor context)
        {
            _context = context;
        }
        public bool HasUser()
        {
            AuthenticationResponse user = _context.HttpContext.Session.Get<AuthenticationResponse>("user");

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
