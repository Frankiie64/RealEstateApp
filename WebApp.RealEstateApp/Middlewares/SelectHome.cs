using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using RealEstateApp.Core.Application.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.RealEstateApp.Controllers;
using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Core.Application.helper;
using WebApp.RealEstateApp.middlewares;

namespace WebApp.RealEstateApp.Middlewares
{
    public class SelectHome : IAsyncActionFilter
    {
        private readonly IHttpContextAccessor httpContext;
        private readonly AuthenticationResponse user;
        private readonly ValidSession _userSession;

        public SelectHome(IHttpContextAccessor httpContext, ValidSession _userSession)
        {
            this._userSession = _userSession;
            this.httpContext = httpContext;
            user = httpContext.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!_userSession.HasUser())
            {
                await next();
                return;
            }          
            if (user.Roles.Any(x => x == Roles.Client.ToString()))
            {
                await next();
                return;
            }
            if (user.Roles.Any(r => r == Roles.Agent.ToString()))
            {
                var controller = (HomeController)context.Controller;
                context.Result = controller.RedirectToAction("Index", "RAgent");
            }
            if (user.Roles.Any(r => r == Roles.Admin.ToString()))
            {
                var controller = (HomeController)context.Controller;
                context.Result = controller.RedirectToAction("Dashboard","Admin");
            }
            if (user.Roles.Any(r => r == Roles.SuperAdmin.ToString()))
            {
                var controller = (HomeController)context.Controller;
                context.Result = controller.RedirectToAction("Dashboard", "Admin");
            }

        }
    }
}
