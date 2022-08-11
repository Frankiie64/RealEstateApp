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

namespace RealEstateApp.Core.Application.Features.TypeProperties.Commands.UpdateTypeProperty
{
    public class UpdateTypePropertyCommand : SaveTypePropertyDto, IRequest<TypePropertyUpdateResponse>
    {
    }

    public class UpdateTypePropertyCommandHandler : IRequestHandler<UpdateTypePropertyCommand, TypePropertyUpdateResponse>
    {
        private readonly ITypePropertyRepository _typePropertyRepository;
        private readonly IMapper _mapper;
        public UpdateTypePropertyCommandHandler(ITypePropertyRepository typePropertyRepository, IMapper mapper)
        {

            _typePropertyRepository = typePropertyRepository;
            _mapper = mapper;
        }
        public async Task<TypePropertyUpdateResponse> Handle(UpdateTypePropertyCommand command, CancellationToken cancellationToken)
        {
            var typeProperty = await _typePropertyRepository.GetByIdAsync(command.Id);

            if (typeProperty == null)
            {
                throw new Exception($"Type Property Not Found.");
            }
            else
            {
                typeProperty = _mapper.Map<TypeProperty>(command);
                await _typePropertyRepository.UpdateAsync(typeProperty, typeProperty.Id);
                var typePropertyDto = _mapper.Map<TypePropertyUpdateResponse>(typeProperty);

                return typePropertyDto;
            }
        }

    }

}

