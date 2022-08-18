using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using RealEstateApp.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Services.ServicesApp
{
    public class TypePropertyServices : GenericServices<SaveTypePropertyViewModel, TypePropertyViewModel, TypeProperty>, ITypePropertyService
    {

        private readonly IMapper mapper;
        private readonly ITypePropertyRepository repo;

        public TypePropertyServices(IMapper mapper, ITypePropertyRepository repo) : base(repo, mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }


        public async Task<List<TypePropertyViewModel>> GetAllViewModelWithInclude()
        {
            var typePropertyList = await repo.GetAllWithIncludeAsync(new List<string> { "Properties" });

            return typePropertyList.Select(typeProperty => new TypePropertyViewModel
            {
                Id = typeProperty.Id,
                Name = typeProperty.Name,
                Description = typeProperty.Description,
                PropertiesQuantity = typeProperty.Properties.Where(property => property.TypeSaleId == typeProperty.Id).Count()
            }).ToList();
        }
    }

}

