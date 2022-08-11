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

namespace RealEstateApp.Core.Application.Features.Properties.Queries.GetAllProperties
{
    public class GetAllPropertiesQuery : IRequest<IList<PropertyDto>>
    {

    }

    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, IList<PropertyDto>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;


        public GetAllPropertiesQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<IList<PropertyDto>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            var propertyDto = await GetAllDto();
            return propertyDto;
        }

        private async Task<List<PropertyDto>> GetAllDto()
        {
            var propertyList = await _propertyRepository.GetAllWithIncludeAsync(new List<string> { "Improvements", "TypeProperty", "TypeSale" });

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
                TypeProperty = _mapper.Map<TypePropertyDto>(property.TypeProperty),
                TypeSale = _mapper.Map<TypeSaleDto>(property.TypeSale)
            }).ToList();
        }
    }

}
