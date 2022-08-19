using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using WebApp.RealEstateApp.Controllers;

namespace WebApp.RealEstateApp.middlewares
{
    public class LoginAuthorize: IAsyncActionFilter
    {
        private readonly ValidSession _userSession;
        public LoginAuthorize(ValidSession userSession, IHttpContextAccessor context)
        {
            _userSession = userSession;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_userSession.HasUser())
            {
                var controller = (UserController)context.Controller;
                context.Result = controller.RedirectToAction("index", "home");
            }
            else
            {
                await next();
            }

        }
    }
}
