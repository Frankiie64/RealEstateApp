using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Property;
using RealEstateApp.Core.Application.Dtos.TypeProperty;
using RealEstateApp.Core.Application.Dtos.TypeSale;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.ViewModels.Property;
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
        private readonly IMapper _mapper;


        public GetPropertyByIdQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var property = await GetByIdDto(request.Id);
            return property;
        }

        public async Task<PropertyDto> GetByIdDto(int id)
        {
            var propertyList = await _propertyRepository.GetAllWithIncludeAsync(new List<string> { "Improvements", "TypeProperty", "TypeSale" });

            var property = propertyList.FirstOrDefault(f => f.Id == id);
            if (property == null) throw new Exception($"Property Not Found.");

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
                TypeProperty = _mapper.Map<TypePropertyDto>(property.TypeProperty),
                TypeSale = _mapper.Map<TypeSaleDto>(property.TypeSale)
            };

            
            return propertyDto;
        }


    }
}
