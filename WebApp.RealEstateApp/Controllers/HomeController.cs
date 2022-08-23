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
            ViewBag.TypeProperties = await serviceTypeProperty.GetAllViewModelAsync();

            return View();
        }
        [ServiceFilter(typeof(SelectHome))]
        public async Task<IActionResult> PropertysByFilter(PropertyByFiltering filter)
        {
            ViewBag.TypeProperties = await serviceTypeProperty.GetAllViewModelAsync();

            var Properties = await serviceProperty.GetAllViewModelWithIncludeByFilterAsync(filter);

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


        //Dashboard
        public async Task<IActionResult> IndexAdmin(int id)
        {

            var properties = await serviceProperty.GetAllViewModelWithIncludeAsync();
            var agents = await userService.GetAllAgentAsync(); 
            var clients = await userService.GetAllClientsAsync();
            var developers = await userService.GetAllDevelopersAsync();


            DashboardViewModel dashBoard = new()
            {
                PropertiesQuantity = properties.Count(),
                AgentActive = agents.Where(agent => agent.IsActive == true).Count(),
                AgentDisabled = agents.Where(agent => agent.IsActive == false).Count(),
                ClientActive = clients.Where(client => client.IsActive == true).Count(),
                ClientDisabled = clients.Where(client => client.IsActive == false).Count(),
                DeveloperActive = developers.Where(dev => dev.IsActive == true).Count(),
                DeveloperDisabled = developers.Where(dev => dev.IsActive == false).Count()
            };

            return View("Dashboard", dashBoard);
        }

    }
}
