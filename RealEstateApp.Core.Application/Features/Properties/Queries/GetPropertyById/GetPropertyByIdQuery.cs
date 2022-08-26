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
using RealEstateApp.Core.Application.ViewModels.TypeImproments;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Properties.Queries.GetPropertyById
{
    public class GetPropertyByIdQuery : IRequest<PropertyDto>
    {
        public int Id { get; set; }
    }

    public class GetPropertyByIdQueryHandler : IRequestHandler<GetPropertyByIdQuery, PropertyDto>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IImprovementRepository _improvementRepository;
        private readonly ITypeImpromentRepository _typeImpromentRepository;
        private readonly IPropertyService _propertyService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public GetPropertyByIdQueryHandler(IPropertyRepository propertyRepository, IMapper mapper, IImprovementRepository improvementRepository, ITypeImpromentRepository typeImpromentRepository, IPropertyService propertyService, IUserService userService)
        {
            _propertyRepository = propertyRepository;
            _improvementRepository = improvementRepository;
            _propertyService = propertyService;
            _userService = userService;
            _mapper = mapper;
            _typeImpromentRepository = typeImpromentRepository;
        }

        public async Task<PropertyDto> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var property = await GetByIdDto(request.Id);
            return property;
        }

        public async Task<PropertyDto> GetByIdDto(int id)
        {
            var propertyList = await _propertyService.GetAllViewModelWithIncludeAsync();
            propertyList = propertyList.Where(property => property.agent != null).ToList();
            if (propertyList.Where(x => x.Id == id).Count() < 1) throw new Exception($"Property Not Found.");

            var users = await _userService.GetAllUsersAsync();

            var improvements = await _improvementRepository.GetAllWithIncludeAsync(new List<string> { "typeImproments" });
            var typeImprovements = await _typeImpromentRepository.GetAllAsync();

            var property = propertyList.FirstOrDefault(f => f.Id == id);

            PropertyDto propertyDto = new()
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
                AgentName = users.FirstOrDefault(x => x.Id == property.AgentId).Firstname + " " + users.FirstOrDefault(x => x.Id == property.AgentId).Lastname,
                TypeProperty = _mapper.Map<TypePropertyDto>(property.TypeProperty),
                TypeSale = _mapper.Map<TypeSaleDto>(property.TypeSale),
                Improvements = _mapper.Map<List<ImprovementDto>>(typeImprovements.Where(x => x.IdProperty == id).Select(typeImprovement => new ImprovementDto
                {
                    Id = typeImprovement.IdImproment,
                    Name = typeImprovement.Improvement.Name,
                    Description = typeImprovement.Improvement.Description
                })).ToList()
            };


            return propertyDto;
        }


    }
}
