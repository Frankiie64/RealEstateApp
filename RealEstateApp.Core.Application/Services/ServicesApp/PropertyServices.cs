using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
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
        private readonly ITypeImpromentsServices ImpromentService;
        private readonly IUserService userService;

        public PropertyServices(IMapper mapper, IPropertyRepository repo, IPhotosPropertyRepository PhotoRepo, IUserService userService,
            ITypeImpromentsServices ImpromentService) : base(repo,mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
            this.userService = userService;
            this.ImpromentService = ImpromentService;
        }
        public override async  Task<SavePropertyViewModel> CreateAsync(SavePropertyViewModel vm)
        {
            var list = await repo.GetAllAsync();

            if (list.Count == 0)
            {
                vm.Code = 100000;
            }
            else
            {
                vm.Code = 1 + list.Max(x => x.Code);
            }

            return await base.CreateAsync(vm);
        }
        public async Task<List<PropertyViewModel>> GetAllViewModelWithIncludeAsync()
        {
            var entityList = await repo.GetAllWithIncludeAsync(new List<string> { "TypeProperty", "TypeSale", "Improments", "UrlPhotos" });
            entityList = entityList.OrderByDescending(x => x.Creadted).ToList();

            var listMapped = mapper.Map<List<PropertyViewModel>>(entityList);
            var users = await userService.GetAllUsersAsync();
            var improvemnts = await ImpromentService.GetAllViewModelWithIncludeAsync();

            foreach (var item in listMapped)
            {
                item.agent = users.Where(agent => agent.Id == item.AgentId).SingleOrDefault();
                item.Improvements = improvemnts.Where(improvement => improvement.IdProperty == item.Id).Select(x=>x.Improvement).ToList();
            }
           
            return listMapped;
        }

        public async Task<List<PropertyViewModel>> GetAllViewModelWithIncludeByFilterAsync(PropertyByFiltering filter)
        {
            var entityList = await repo.GetAllWithIncludeAsync(new List<string> { "TypeProperty", "TypeSale", "Improments", "UrlPhotos" });
            entityList = entityList.OrderByDescending(x => x.Creadted).ToList();

            var listMapped = mapper.Map<List<PropertyViewModel>>(entityList);

            var users = await userService.GetAllUsersAsync();

            foreach (var item in listMapped)
            {
                item.agent = users.Where(agent => agent.Id == item.AgentId).SingleOrDefault();
            }

            if (filter.code != 0)
            {
                listMapped = listMapped.Where(x => x.Code == filter.code).ToList();
            }            

            if (filter.IdTypeProperty.Count() != 0 && !filter.IdTypeProperty.Any(x=> x == 0))
            {
                List<PropertyViewModel> filtro = new List<PropertyViewModel>();

                listMapped.ForEach(x =>
               filtro.Add(filter.IdTypeProperty.Any(prop => prop == x.TypePropertyId) ? x: null)
                );
                listMapped = filtro.Where(x => x != null).ToList();
            }

            return listMapped.Where(x =>           

            (x.Bathroom >= (filter.MinBathRooms != 0 ? filter.MinBathRooms : 0) && x.Bathroom <= (filter.MaxBathRooms != 0 ? filter.MaxBathRooms : x.Bathroom)) &&

            (x.Room >= (filter.MinRooms != 0?filter.MinRooms:0)  && x.Room <= (filter.MaxRooms != 0 ? filter.MaxRooms: x.Room)) &&

            (x.Price >= (filter.MinPrince != 0 ? filter.MinPrince : 0) && x.Price <= (filter.MaxPrice != 0 ? filter.MaxPrice : x.Price)) 

            ).ToList();
        }
       
    }
}
