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

namespace RealEstateApp.Core.Application.Features.TypeSales.Commands.UpdateTypeSale
{
    public class UpdateTypeSaleCommand : SaveTypeSaleDto, IRequest<TypeSaleUpdateResponse>
    {
    }

    public class UpdateTypeSaleCommandHandler : IRequestHandler<UpdateTypeSaleCommand, TypeSaleUpdateResponse>
    {
        private readonly ITypeSaleRepository _typeSaleRepository;
        private readonly IMapper _mapper;

        public UpdateTypeSaleCommandHandler(ITypeSaleRepository typeSaleRepository, IMapper mapper)
        {
            _typeSaleRepository = typeSaleRepository;
            _mapper = mapper;
        }

        public async Task<TypeSaleUpdateResponse> Handle(UpdateTypeSaleCommand command, CancellationToken cancellationToken)
        {
            var typeSale = await _typeSaleRepository.GetByIdAsync(command.Id);

            if (typeSale == null)
            {
                throw new Exception($"Type Sale Not Found.");
            }
            else
            {
                typeSale = _mapper.Map<RealEstateApp.Core.Domain.Entities.TypeSale>(command);
                await _typeSaleRepository.UpdateAsync(typeSale, typeSale.Id);
                var typePropertyDto = _mapper.Map<TypeSaleUpdateResponse>(typeSale);

                return typePropertyDto;
            }
        }
    }

}
