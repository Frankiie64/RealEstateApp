using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.TypeProperty;
using RealEstateApp.Core.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.TypeProperties.Queries.GetTypePropertyById
{
    public class GetTypePropertyByIdQuery : IRequest<TypePropertyDto>
    {
        public int Id { get; set; }
    }

    public class GetTypePropertyByIdQueryHandler : IRequestHandler<GetTypePropertyByIdQuery, TypePropertyDto>
    {
        private readonly ITypePropertyRepository _typePropertyRepository;
        private readonly IMapper _mapper;

        public GetTypePropertyByIdQueryHandler(ITypePropertyRepository typePropertyRepository, IMapper mapper)
        {
            _typePropertyRepository = typePropertyRepository;
            _mapper = mapper;
        }

        public async Task<TypePropertyDto> Handle(GetTypePropertyByIdQuery query, CancellationToken cancellationToken)
        {
            var typeProperties = await _typePropertyRepository.GetAllAsync();
            var typeProperty = typeProperties.FirstOrDefault(x => x.Id == query.Id);

            if (typeProperty == null) throw new Exception("Property Type Not Found");
            return _mapper.Map<TypePropertyDto>(typeProperty);

        }
    }
}
