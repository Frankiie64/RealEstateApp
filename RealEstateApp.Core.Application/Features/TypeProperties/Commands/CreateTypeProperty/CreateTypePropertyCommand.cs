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

namespace RealEstateApp.Core.Application.Features.TypeProperties.Commands.CreateTypeProperty
{
    public class CreateTypePropertyCommand : CreateTypePropertyDto, IRequest<int>
    {
    }

    public class CreateTypePropertyCommandHandler : IRequestHandler<CreateTypePropertyCommand, int>
    {
        private readonly ITypePropertyRepository _typePropertyRepository;
        private readonly IMapper _mapper;

        public CreateTypePropertyCommandHandler(ITypePropertyRepository typePropertyRepository, IMapper mapper)
        {
            _typePropertyRepository = typePropertyRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTypePropertyCommand command, CancellationToken cancellationToken)
        {
            var typeProperty = _mapper.Map<TypeProperty>(command);
            await _typePropertyRepository.createAsync(typeProperty);
            return typeProperty.Id;
        }
    }
}
