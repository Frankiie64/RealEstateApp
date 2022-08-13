using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{
    public class AgentController : Controller
    {
        private readonly IUserService userService;
        private readonly IHttpContextAccessor context;
        private readonly IPropertyService propertyServices;
        AuthenticationResponse user;

        public AgentController(IHttpContextAccessor context, IUserService userService,IPropertyService propertyServices)
        {
            this.userService = userService;
            this.context = context;
            this.propertyServices = propertyServices;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Agents = await userService.GetAllAgentAsync();
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var Listagent = await userService.GetAllAgentAsync();
            var listProperties = await propertyServices.GetAllViewModelWithIncludeAsync();
            var agent = Listagent.Where(x => x.Id == id).SingleOrDefault();

            agent.Properties = listProperties.Where(x => x.AgentId == id).ToList();
            
            return View(agent);
        }
    }
}
