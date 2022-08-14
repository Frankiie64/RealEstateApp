using MediatR;
using RealEstateApp.Core.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.TypeProperties.Commands.DeleteTypePropertyById
{
    public class DeleteTypePropertyByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteTypePropertyByIdCommandHandler : IRequestHandler<DeleteTypePropertyByIdCommand, int>
    {
        private readonly ITypePropertyRepository _typePropertyRepository;

        public DeleteTypePropertyByIdCommandHandler(ITypePropertyRepository typePropertyRepository)
        {
            _typePropertyRepository = typePropertyRepository;
        }

        public async Task<int> Handle(DeleteTypePropertyByIdCommand command, CancellationToken cancellationToken)
        {
            var typeProperty = await _typePropertyRepository.GetByIdAsync(command.Id);
            if (typeProperty == null) throw new Exception($"Property Type Not Found.");
            await _typePropertyRepository.DeleteAsync(typeProperty);
            return typeProperty.Id;
        }
    }

}
