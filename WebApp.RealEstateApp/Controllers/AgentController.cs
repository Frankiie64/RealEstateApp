using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.Agent;
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
        private readonly IMapper _mapper;

        AuthenticationResponse user;

        public AgentController(IHttpContextAccessor context, IUserService userService, IPropertyService propertyServices, IMapper mapper)
        {
            this.userService = userService;
            this.context = context;
            this.propertyServices = propertyServices;
            _mapper = mapper;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<IActionResult> Index()
        {
            var agents = await userService.GetAllAgentAsync();
            agents = agents.Where(x => x.IsActive == true).OrderBy(x=>x.Firstname).ToList();
            ViewBag.Agents = agents;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string fullname)
        {
            
            var agents = await userService.GetAllAgentAsync();

            agents = agents.OrderBy(x => x.Firstname).ToList();

            if (string.IsNullOrWhiteSpace(fullname))
            {
                ViewBag.Agents = agents;
                return View();
            }
            List<string> PartName = fullname.Split(" ").ToList();

            var filter = new List<AgentVM>();
            var order = new List<UserVM>();

            foreach (var name in PartName)
            {
                filter = agents.Where(x => x.Firstname.ToLower().Contains(name.ToLower()) || x.Lastname.ToLower().Contains(name.ToLower())).ToList();

                if (filter.Count != 0)
                {
                    foreach (var item in filter)
                    {
                       order.Add(item);
                    }
                }

                filter.Clear();
            }
            order = order.OrderBy(x => x.Firstname).ToList();
            ViewBag.Agents = order;
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

        [Authorize(Roles = "SuperAdmin, Admin")]

        public async Task<IActionResult> AgentList()
        {
            var agents = _mapper.Map<List<AgentVM>>(await userService.GetAllAgentAsync());
            var listProperties = await propertyServices.GetAllViewModelWithIncludeAsync();
            foreach (var agent in agents)
            {
                agent.PropertyQuantity = listProperties.Where(property => property.AgentId == agent.Id).Count();
            }

            ViewBag.AgentList = agents;
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Admin")]

        public async Task<IActionResult> IsActive(UserVM vm)
        {
            if (vm.Id == user.Id)
            {
                return RedirectToRoute(new { controller = "User", action = "AccessDenied" });
            }
            await userService.IsActive(vm.Id);

            return RedirectToRoute
                (new { controller = "Agent", action = "AgentList" });
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            return View(_mapper.Map<SaveUserVM>(await userService.GetUserByIdAsync(id)));
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> DeletePost(string id)
        {
            await userService.DeleteUserAsync(id);
            return RedirectToRoute(new { controller = "Agent", action = "AgentList" });
        }

    }
}
