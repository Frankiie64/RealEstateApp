using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Interfaces.Service
{
    public interface ITypePropertyService : IGenericServices<SaveTypePropertyViewModel, TypePropertyViewModel, TypeProperty>
    {
        Task<List<TypePropertyViewModel>> GetAllViewModelWithInclude();
    }
}
