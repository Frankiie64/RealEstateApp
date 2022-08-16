using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.ViewModels.FavoriteProperty;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Services.ServicesApp
{
    public class FavoritePropertyServices : GenericServices<SaveFavoritePropertyViewModel, FavoritePropertyViewModel, FavoriteProperty>, IFavoritePropertyServices
    {
        private readonly IMapper mapper;
        private readonly IFavoritePropertyRepository repo;
        public FavoritePropertyServices(IMapper mapper, IFavoritePropertyRepository repo) : base(repo, mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
    }
}
