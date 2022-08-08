using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using RealEstateApp.Core.Domain.Entities;

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

      
    }

}

