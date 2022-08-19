using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.ViewModels.FavoriteProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{
    [Authorize(Roles = "Client")]
    public class ClientController : Controller
    {
        
        private readonly IFavoritePropertyServices serviceFavProperty;
        private readonly IPropertyService serviceProperty;
        private readonly IHttpContextAccessor context;
        AuthenticationResponse user;

        public ClientController(IHttpContextAccessor context, IFavoritePropertyServices serviceFavProperty, IPropertyService serviceProperty)
        {           
            this.serviceFavProperty = serviceFavProperty;
            this.serviceProperty = serviceProperty;
            this.context = context;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        public async Task<IActionResult> PropertiesFavorite()
        {          
            var Properties = await serviceProperty.GetAllViewModelWithIncludeAsync();

            var ListFavorite = await serviceFavProperty.GetAllViewModelAsync();
            ListFavorite = ListFavorite.Where(x => x.IdUser == user.Id).ToList();

            foreach (var item in Properties)
            {
                if (ListFavorite.Any(x => x.PropertyId == item.Id))
                {
                    item.IsFavorite = true;
                }
            }

            ViewBag.Properties = Properties.Where(x => x.IsFavorite == true).ToList();

            return View();
        }

        public async Task<IActionResult> EstatusFavorite(int id)
        {
            var List = await serviceFavProperty.GetAllViewModelAsync();

            if (List.Any(x => x.IdUser == user.Id && x.PropertyId == id))
            {
                var fav = List.Where(x => x.IdUser == user.Id && x.PropertyId == id).FirstOrDefault();
                await serviceFavProperty.DeleteAsync(fav.Id);
            }
            else
            {
                SaveFavoritePropertyViewModel favorite = new SaveFavoritePropertyViewModel
                {
                    IdUser = user.Id,
                    PropertyId = id
                };
                var resp = await serviceFavProperty.CreateAsync(favorite);
            }

                return RedirectToRoute(new { controller = "Client", action = "PropertiesFavorite" });
            
        }
    }
}
