using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.Property;
using RealEstateApp.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Interfaces.Service
{
    public interface IPropertyService : IGenericServices<SavePropertyViewModel, PropertyViewModel, Property>
    {
        Task<List<PropertyViewModel>> GetAllViewModelWithIncludeAsync();
        Task<List<PropertyViewModel>> GetAllViewModelWithIncludeByFilterAsync(PropertyByFiltering filter);

    }
}
