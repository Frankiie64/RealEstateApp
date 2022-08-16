﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.ViewModels.Property;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyService serviceProperty;
        private readonly ITypePropertyService serviceTypeProperty;
        private readonly IHttpContextAccessor context;
        AuthenticationResponse user;

        public HomeController(IPropertyService serviceProperty, ITypePropertyService serviceTypeProperty, IHttpContextAccessor context)
        {
            this.serviceProperty = serviceProperty;
            this.serviceTypeProperty = serviceTypeProperty;
            this.context = context;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<IActionResult> Index()
        {
            if (user != null)
            {

            }

            ViewBag.Propertys = await serviceProperty.GetAllViewModelWithIncludeAsync();
            ViewBag.TypePropertys = await serviceTypeProperty.GetAllViewModelAsync();

            return View();
        }

        public async Task<IActionResult> PropertysByFilter(PropertyByFiltering filter)
        {
            ViewBag.TypePropertys = await serviceTypeProperty.GetAllViewModelAsync();

            ViewBag.Propertys = await serviceProperty.GetAllViewModelWithIncludeByFilterAsync(filter);

            return View("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            // No me mire, no hay mucho tiempo xD
            var properties = await serviceProperty.GetAllViewModelWithIncludeAsync();
            var property = properties.Where(property => property.Id == id).SingleOrDefault();
            return View("Details",property);
        }


    }
}
