using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.TypeProperty;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.TypeProperties.Queries.GetAllTypeProperties
{
    public class GetAllTypePropertiesQuery : IRequest<IEnumerable<TypePropertyDto>>
    {
    }

    public class GetAllTypePropertiesQueryHandler : IRequestHandler<GetAllTypePropertiesQuery, IEnumerable<TypePropertyDto>>
    {
        private readonly ITypePropertyRepository _typePropertyRepository;
        private readonly IMapper _mapper;

        public GetAllTypePropertiesQueryHandler(ITypePropertyRepository typePropertyRepository, IMapper mapper)
        {
            _typePropertyRepository = typePropertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypePropertyDto>> Handle(GetAllTypePropertiesQuery request, CancellationToken cancellationToken)
        {
            var typePropertyDto  = await GetAllDto();
            return typePropertyDto;
        }

        //Si esto no funciona, hacerlo de la forma tradicional
        private async Task<List<TypePropertyDto>> GetAllDto()
        {
            var propertyList = await _typePropertyRepository.GetAllAsync();

            return _mapper.Map<List<TypePropertyDto>>(propertyList);
        }
    }
}
