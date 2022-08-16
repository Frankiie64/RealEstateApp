using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.ViewModels.FavoriteProperty;
using RealEstateApp.Core.Application.ViewModels.Property;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyService serviceProperty;
        private readonly IFavoritePropertyServices serviceFavProperty;
        private readonly ITypePropertyService serviceTypeProperty;
        private readonly IHttpContextAccessor context;
        AuthenticationResponse user;

        public HomeController(IPropertyService serviceProperty, ITypePropertyService serviceTypeProperty, IHttpContextAccessor context, IFavoritePropertyServices serviceFavProperty)
        {
            this.serviceProperty = serviceProperty;
            this.serviceFavProperty = serviceFavProperty;
            this.serviceTypeProperty = serviceTypeProperty;
            this.context = context;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

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
