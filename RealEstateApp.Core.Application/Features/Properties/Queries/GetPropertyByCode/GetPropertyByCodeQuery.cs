using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Improvement;
using RealEstateApp.Core.Application.Dtos.Property;
using RealEstateApp.Core.Application.Dtos.TypeProperty;
using RealEstateApp.Core.Application.Dtos.TypeSale;
using RealEstateApp.Core.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Properties.Queries.GetPropertyByCode
{
    public class GetPropertyByCodeQuery : IRequest<PropertyDto>
    {
        public int Code { get; set; }
    }

    public class GetPropertyByCodeQueryHandler : IRequestHandler<GetPropertyByCodeQuery, PropertyDto>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IImprovementRepository _improvementRepository;
        private readonly ITypeImpromentRepository _typeImpromentRepository;
        private readonly IMapper _mapper;
        public GetPropertyByCodeQueryHandler(IPropertyRepository propertyRepository, IImprovementRepository improvementRepository, ITypeImpromentRepository typeImpromentRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _improvementRepository = improvementRepository;
            _typeImpromentRepository = typeImpromentRepository;
            _mapper = mapper;
        }


        public async Task<PropertyDto> Handle(GetPropertyByCodeQuery request, CancellationToken cancellationToken)
        {
            var property = await GetByCodeDto(request.Code);
            if (property == null) throw new Exception("Property Not Found");
            return property;
        }

        public async Task<PropertyDto> GetByCodeDto(int Code)
        {
            var propertyList = await _propertyRepository.GetAllWithIncludeAsync(new List<string> { "Improments", "TypeProperty", "TypeSale" });
            if (propertyList.Where(x => x.Code == Code).Count() < 1) throw new Exception($"Property Not Found.");

            var improvements = await _improvementRepository.GetAllWithIncludeAsync(new List<string> { "typeImproments" });
            var typeImprovements = await _typeImpromentRepository.GetAllAsync();

            var property = propertyList.FirstOrDefault(f => f.Code == Code);

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
                TypeSale = _mapper.Map<TypeSaleDto>(property.TypeSale),
                Improvements = _mapper.Map<List<ImprovementDto>>(typeImprovements.Where(x => x.IdProperty == property.Id).Select(typeImprovement => new ImprovementDto
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
