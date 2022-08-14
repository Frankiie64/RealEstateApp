using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.Property;
using RealEstateApp.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Services.ServicesApp
{
    public class PropertyServices : GenericServices<SavePropertyViewModel,PropertyViewModel, Property>, IPropertyService
    {
        private readonly IMapper mapper;
        private readonly IPropertyRepository repo;
        private readonly IUserService userService;

        public PropertyServices(IMapper mapper, IPropertyRepository repo, IPhotosPropertyRepository PhotoRepo, IUserService userService) : base(repo,mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
            this.userService = userService;
        }

        public async Task<List<PropertyViewModel>> GetAllViewModelWithIncludeAsync()
        {
            var entityList = await repo.GetAllWithIncludeAsync(new List<string> { "TypeProperty", "TypeSale", "Improvements", "UrlPhotos" });

            var listMapped = mapper.Map<List<PropertyViewModel>>(entityList);
            var users = await userService.GetAllUsersAsync();

            foreach (var item in listMapped)
            {
                item.agent = users.Where(agent => agent.Id == item.AgentId).SingleOrDefault();
            }

            return listMapped;
        }

        public async Task<List<PropertyViewModel>> GetAllViewModelWithIncludeByFilterAsync(PropertyByFiltering filter)
        {
            var entityList = await repo.GetAllWithIncludeAsync(new List<string> { "TypeProperty", "TypeSale", "Improvements", "PropertyImprovements", "UrlPhotos" });

            var listMapped = mapper.Map<List<PropertyViewModel>>(entityList);

            var users = await userService.GetAllUsersAsync();

            foreach (var item in listMapped)
            {
                item.agent = users.Where(agent => agent.Id == item.AgentId).SingleOrDefault();
            }

            return listMapped.Where(x =>

            (x.Code != 0 ? x.Code == x.Code : x.Code != 0) &&

            (x.Bathroom >= (filter.MinBathRooms != 0 ? filter.MinBathRooms : 0) && x.Bathroom <= (filter.MaxBathRooms != 0 ? filter.MaxBathRooms : x.Bathroom)) &&

            (x.Room >= (filter.MinRooms != 0?filter.MinRooms:0)  && x.Room <= (filter.MaxRooms != 0 ? filter.MaxRooms: x.Room)) &&

            (x.Price >= (filter.MinPrince != 0 ? filter.MinPrince : 0) && x.Price <= (filter.MaxPrice != 0 ? filter.MaxPrice : x.Price)) 

            ).ToList();
        }
       
    }
}
