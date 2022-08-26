using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Improvement;
using RealEstateApp.Core.Application.Dtos.Property;
using RealEstateApp.Core.Application.Dtos.TypeProperty;
using RealEstateApp.Core.Application.Dtos.TypeSale;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.Property;
using RealEstateApp.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Properties.Queries.GetAllProperties
{
    public class GetAllPropertiesQuery : IRequest<IList<PropertyDto>>
    {

    }

    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, IList<PropertyDto>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IImprovementRepository _improvementRepository;
        private readonly ITypeImpromentRepository _typeImpromentRepository;
        private readonly IPropertyService _propertyService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public GetAllPropertiesQueryHandler(IPropertyRepository propertyRepository, IMapper mapper, IUserService userService, IImprovementRepository improvementRepository, ITypeImpromentRepository typeImpromentRepository, IPropertyService propertyService)
        {
            _propertyRepository = propertyRepository;
            _improvementRepository = improvementRepository;
            _typeImpromentRepository = typeImpromentRepository;
            _userService = userService;
            _propertyService = propertyService;
            _mapper = mapper;
        }

        public async Task<IList<PropertyDto>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            var propertyDto = await GetAllDto();
            return propertyDto;
        }

        private async Task<List<PropertyDto>> GetAllDto()
        {

            var properties = await _propertyService.GetAllViewModelWithIncludeAsync();
            var propertyList = properties.Where(property => property.agent != null).ToList();
            var users = await _userService.GetAllUsersAsync();

            var improvements = await _improvementRepository.GetAllWithIncludeAsync(new List<string> { "typeImproments" });
            var typeImprovements = await _typeImpromentRepository.GetAllAsync();


            return propertyList.Select(property => new PropertyDto
            {

                Code = property.Code,
                Location = property.Location,
                Id = property.Id,
                Room = property.Room,
                Price = property.Price,
                Description = property.Description,
                Meters = property.Meters,
                Bathroom = property.Bathroom,
                AgentId = property.AgentId,
                AgentName = users.FirstOrDefault(x => x.Id == property.AgentId).Firstname + " "+  users.FirstOrDefault(x => x.Id == property.AgentId).Lastname,
                TypeProperty = _mapper.Map<TypePropertyDto>(property.TypeProperty),
                TypeSale = _mapper.Map<TypeSaleDto>(property.TypeSale),
                Improvements = _mapper.Map<List<ImprovementDto>>(typeImprovements.Where(x => x.IdProperty == property.Id).Select(typeImprovement => new ImprovementDto
                {
                    Id = typeImprovement.IdImproment,
                    Name = typeImprovement.Improvement.Name,
                    Description = typeImprovement.Improvement.Description
                }).ToList())

            }).ToList();
        }
    }
}


