using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.ViewModels.TypeImproments;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Services.ServicesApp
{
   public class TypeImpromentServices:GenericServices<SaveTypeImpromentsViewModel,TypeImpromentsViewModel,TypeImproments>, ITypeImpromentsServices
    {
        private readonly IMapper mapper;
        private readonly ITypeImpromentRepository repo;

        public TypeImpromentServices(IMapper mapper, ITypeImpromentRepository repo) : base(repo, mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        public async Task<List<TypeImpromentsViewModel>> GetAllViewModelWithIncludeAsync()
        {
            var list = await repo.GetAllWithIncludeAsync(new List<string> { "Improvement" });

            return  mapper.Map<List<TypeImpromentsViewModel>>(list);
        }
    }
}
