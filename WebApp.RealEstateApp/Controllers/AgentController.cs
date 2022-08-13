using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.Users;
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

        public AgentController(IHttpContextAccessor context, IUserService userService, IPropertyService propertyServices)
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

        [HttpPost]
        public async Task<IActionResult> Index(string fullname)
        {
            var agents = await userService.GetAllAgentAsync();
            List<string> PartName = fullname.Split(" ").ToList();

            var filter = new List<UserVM>();
            ViewBag.Agents = new List<UserVM>();

            foreach (var name in PartName)
            {
                filter = agents.Where(x => x.Firstname.ToLower().Contains(name.ToLower()) || x.Lastname.ToLower().Contains(name.ToLower())).ToList();

                if (filter.Count != 0)
                {
                    foreach (var item in filter)
                    {
                        ViewBag.Agents.Add(item);
                    }
                }

                filter.Clear();
            }
            
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
