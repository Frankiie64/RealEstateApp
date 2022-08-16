using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
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
        private readonly IHttpContextAccessor context;
        AuthenticationResponse user;

        public ClientController(IHttpContextAccessor context, IFavoritePropertyServices serviceFavProperty)
        {
           
            this.serviceFavProperty = serviceFavProperty;
            this.context = context;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
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

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            
        }
    }
}
