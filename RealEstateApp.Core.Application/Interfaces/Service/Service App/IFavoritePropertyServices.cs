using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.FavoriteProperty;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Interfaces.Service.Service_App
{
   public interface IFavoritePropertyServices : IGenericServices<SaveFavoritePropertyViewModel, FavoritePropertyViewModel, FavoriteProperty>
    {
    }
}
