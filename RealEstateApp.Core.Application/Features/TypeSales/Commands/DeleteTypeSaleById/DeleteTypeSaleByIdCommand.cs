using MediatR;
using RealEstateApp.Core.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.TypeSales.Commands.DeleteTypeSaleById
{
    public class DeleteTypeSaleByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteTypeSaleByIdCommandHandler : IRequestHandler<DeleteTypeSaleByIdCommand, int>
    {
        private readonly ITypeSaleRepository _typeSaleRepository;

        public DeleteTypeSaleByIdCommandHandler(ITypeSaleRepository typeSaleRepository)
        {
            _typeSaleRepository = typeSaleRepository;
        }

        public async Task<int> Handle(DeleteTypeSaleByIdCommand command, CancellationToken cancellationToken)
        {
            var typeSale = await _typeSaleRepository.GetByIdAsync(command.Id);
            if (typeSale == null) throw new Exception($"Type Sale Not Found.");
            await _typeSaleRepository.DeleteAsync(typeSale);
            return typeSale.Id;
        }
    }
}
