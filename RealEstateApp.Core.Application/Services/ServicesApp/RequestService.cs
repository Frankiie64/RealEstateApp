using AutoMapper;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.ViewModels.Request;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Services.ServicesApp
{
    public class RequestService : GenericServices<SaveRequestViewModel, RequestViewModel, Request>, IRequestService
    {
        private readonly IMapper mapper;
        private readonly IRequestRepository repo;

        public RequestService(IMapper mapper, IRequestRepository repo): base(repo,mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

    }
}
