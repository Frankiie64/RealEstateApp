using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.ViewModels.TypeSale;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Services.ServicesApp
{
    public class TypeSaleServices : GenericServices<SaveTypeSaleViewModel, TypeSaleViewModel, TypeSale>, ITypeSaleService
    {
        private readonly IMapper mapper;
        private readonly ITypeSaleRepository repo;
        private readonly IPropertyService serviceProperty;
        public TypeSaleServices(IMapper mapper, ITypeSaleRepository repo, IPropertyService serviceProperty) : base(repo, mapper)
        {
            this.mapper = mapper;
            this.serviceProperty = serviceProperty;
            this.repo = repo;
        }

        public async Task<List<TypeSaleViewModel>> GetAllViewModelWithInclude()
        {
            var typeSaleList = await repo.GetAllWithIncludeAsync(new List<string> { "Properties" });
            var propertyViews = await serviceProperty.GetAllViewModelWithIncludeAsync();

            propertyViews = propertyViews.Where(x => x.agent != null).ToList();

            return typeSaleList.Select(typeSale => new TypeSaleViewModel
            {
                Id = typeSale.Id,
                Name = typeSale.Name,
                Description = typeSale.Description,
                PropertiesQuantity = propertyViews.Where(property => property.TypeSaleId == typeSale.Id).Count()
            }).ToList();
        }

    }
}
