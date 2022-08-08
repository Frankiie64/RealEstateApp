﻿using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service;
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

        public PropertyServices(IMapper mapper, IPropertyRepository repo ): base(repo,mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        public async Task<List<PropertyViewModel>> GetAllViewModelWithIncludeAsync()
        {
            var entityList = await repo.GetAllWithIncludeAsync(new List<string> { "TypeProperty", "TypeSale", "Improvements", "PropertyImprovements" });

            return mapper.Map<List<PropertyViewModel>>(entityList);
        }

        public async Task<List<PropertyViewModel>> GetAllViewModelWithIncludeByFilterAsync(PropertyByFiltering filter)
        {
            var entityList = await repo.GetAllWithIncludeAsync(new List<string> { "TypeProperty", "TypeSale", "Improvements", "PropertyImprovements" });

            var listMapped = mapper.Map<List<PropertyViewModel>>(entityList);

            return listMapped.Where(x =>
            (x.Code.ToString().Contains(filter.code.ToString()))&&
            (x.Bathroom >= filter.MinBathRooms && x.Bathroom <= filter.MaxBathRooms) &&
            (x.Room >= filter.MinRooms && x.Room <= filter.MaxRooms) &&
            (x.Price >= filter.MinPrince && x.Price <= filter.MaxPrice)                               
            ).ToList();
        }
    }
}
