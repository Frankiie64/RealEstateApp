using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.TypeSale;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Interfaces.Service
{
    public interface ITypeSaleService : IGenericServices<SaveTypeSaleViewModel, TypeSaleViewModel, TypeSale>
    {
        Task<List<TypeSaleViewModel>> GetAllViewModelWithInclude();
    }
}
