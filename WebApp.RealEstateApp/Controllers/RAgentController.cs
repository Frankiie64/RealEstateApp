using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{
    [Authorize(Roles = "Agent")]
    public class RAgentController : Controller
    {
        private readonly IPropertyService serviceProperty;
        private readonly IHttpContextAccessor context;
        AuthenticationResponse user;

        public RAgentController(IHttpContextAccessor context, IPropertyService serviceProperty)
        {        
            this.context = context;
            this.serviceProperty = serviceProperty;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        public async Task<IActionResult> Index()
        {
            var Properties = await serviceProperty.GetAllViewModelWithIncludeAsync();
            ViewBag.Properties = Properties.Where(x => x.AgentId == user.Id).ToList();

            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        /*
        public async Task<IActionResult> Edit()
        {

        }
        public async Task<IActionResult> Delete()
        {

        }
        */
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Properties()
        {
            return View();
        }
    }
}
