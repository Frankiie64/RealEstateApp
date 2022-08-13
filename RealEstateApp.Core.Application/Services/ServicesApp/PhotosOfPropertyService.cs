using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.ViewModels.PhotoProperties;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Services.ServicesApp
{
    public class PhotosOfPropertyService : GenericServices<SavePhotosPropertyViewModel,PhotosPropertyViewModel,PhotosOfProperties>, IPhotosOfPropertyService
    {
        private readonly IMapper mapper;
        private readonly IPhotosPropertyRepository repo;

        public PhotosOfPropertyService(IMapper mapper, IPhotosPropertyRepository repo) : base(repo, mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
    }
}
