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

namespace RealEstateApp.Core.Application.Features.TypeSale.Queries.GetAllTypeProperties
{
    public class GetAllTypeSalesQuery : IRequest<IEnumerable<TypeSaleDto>>
    {
    }

    public class GetAllTypeSalesQueryHandler : IRequestHandler<GetAllTypeSalesQuery, IEnumerable<TypeSaleDto>>
    {
        private readonly ITypeSaleRepository _typeSaleRepository;
        private readonly IMapper _mapper;

        public GetAllTypeSalesQueryHandler(ITypeSaleRepository typeSaleRepository, IMapper mapper)
        {
            _typeSaleRepository = typeSaleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeSaleDto>> Handle(GetAllTypeSalesQuery query, CancellationToken cancellationToken)
        {
            var typeSaleDto = await GetAllDto();
            return typeSaleDto;
        }

        private async Task<List<TypeSaleDto>> GetAllDto()
        {
            var propertyList = await _typeSaleRepository.GetAllAsync();

            return _mapper.Map<List<TypeSaleDto>>(propertyList);
        }
    }
}
