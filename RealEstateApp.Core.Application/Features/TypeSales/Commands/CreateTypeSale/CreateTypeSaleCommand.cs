using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.TypeSale;
using RealEstateApp.Core.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.TypeSales.Commands.CreateTypeSale
{
    public class CreateTypeSaleCommand : CreateTypeSaleDto, IRequest<int>
    {
    }

    public class CreateTypeSaleCommandHandler : IRequestHandler<CreateTypeSaleCommand, int>
    {
        private readonly ITypeSaleRepository _typeSaleRepository;
        private readonly IMapper _mapper;

        public CreateTypeSaleCommandHandler(ITypeSaleRepository typeSaleRepository, IMapper mapper)
        {
            _typeSaleRepository = typeSaleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTypeSaleCommand command, CancellationToken cancellationToken)
        {
            var typeSale = _mapper.Map<RealEstateApp.Core.Domain.Entities.TypeSale>(command);
            await _typeSaleRepository.createAsync(typeSale);
            return typeSale.Id;
        }
    }
}
