using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels;
using RealEstateApp.Core.Application.ViewModels.FavoriteProperty;
using RealEstateApp.Core.Application.ViewModels.Property;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.RealEstateApp.middlewares;
using WebApp.RealEstateApp.Middlewares;

namespace WebApp.RealEstateApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IPropertyService serviceProperty;
        private readonly IFavoritePropertyServices serviceFavProperty;
        private readonly ITypePropertyService serviceTypeProperty;
        private readonly IUserService userService;

        private readonly IHttpContextAccessor context;
        AuthenticationResponse user;

        public HomeController(IPropertyService serviceProperty, ITypePropertyService serviceTypeProperty, IHttpContextAccessor context, IFavoritePropertyServices serviceFavProperty, IUserService userService)
        {
            this.serviceProperty = serviceProperty;
            this.serviceFavProperty = serviceFavProperty;
            this.serviceTypeProperty = serviceTypeProperty;
            this.userService = userService;
            this.context = context;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        [ServiceFilter(typeof(SelectHome))]
        public async Task<IActionResult> Index()
        {
            var Properties = await serviceProperty.GetAllViewModelWithIncludeAsync();
            List<PropertyViewModel> propertyList = Properties.Where(property => property.agent != null).ToList();
            if (user != null)
            {
                var ListFavorite = await serviceFavProperty.GetAllViewModelAsync();
                ListFavorite = ListFavorite.Where(x => x.IdUser == user.Id).ToList();

                foreach (var item in Properties)
                {
                    if (ListFavorite.Any(x => x.PropertyId == item.Id))
                    {
                        item.IsFavorite = true;
                    }
                }
            }

            ViewBag.Properties = propertyList;
            ViewBag.TypeProperties = await serviceTypeProperty.GetAllViewModelAsync();

            return View();
        }
        [ServiceFilter(typeof(SelectHome))]
        public async Task<IActionResult> PropertysByFilter(PropertyByFiltering filter)
        {
            ViewBag.TypeProperties = await serviceTypeProperty.GetAllViewModelAsync();

            var Properties = await serviceProperty.GetAllViewModelWithIncludeByFilterAsync(filter);
            Properties = Properties.Where(x => x.agent != null).ToList();

            if (user != null)
            {
                var ListFavorite = await serviceFavProperty.GetAllViewModelAsync();
                ListFavorite = ListFavorite.Where(x => x.IdUser == user.Id).ToList();

                foreach (var item in Properties)
                {
                    if (ListFavorite.Any(x => x.PropertyId == item.Id))
                    {
                        item.IsFavorite = true;
                    }
                }
            }

            ViewBag.Properties = Properties;

            return View("Index");
        }
        [ServiceFilter(typeof(SelectHome))]
        public async Task<IActionResult> Details(int id)
        {
            // No me mire, no hay mucho tiempo xD
            var properties = await serviceProperty.GetAllViewModelWithIncludeAsync();
            var property = properties.Where(property => property.Id == id).SingleOrDefault();
            return View("Details", property);
        }


      

    }
}
