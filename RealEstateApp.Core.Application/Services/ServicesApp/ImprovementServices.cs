using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.ViewModels.Improvement;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Services.ServicesApp
{
    public class ImprovementServices : GenericServices<SaveImprovementViewModel, ImprovementViewModel, Improvement>, IImprovementService
    {
        private readonly IMapper mapper;
        private readonly IImprovementRepository repo;

        public ImprovementServices(IMapper mapper, IImprovementRepository repo) : base(repo, mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
    }
}
