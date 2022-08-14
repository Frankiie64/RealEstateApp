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

namespace RealEstateApp.Core.Application.Features.TypeSale.Queries.GetTypeSaleById
{
    public class GetTypeSaleByIdQuery : IRequest<TypeSaleDto>
    {
        public int Id { get; set; }
    }

    public class GetTypeSaleByIdQueryHandler : IRequestHandler<GetTypeSaleByIdQuery, TypeSaleDto>
    {
        private readonly ITypeSaleRepository _typeSaleRepository;
        private readonly IMapper _mapper;

        public GetTypeSaleByIdQueryHandler(ITypeSaleRepository typeSaleRepository, IMapper mapper)
        {
            _typeSaleRepository = typeSaleRepository;
            _mapper = mapper;
        }

        public async Task<TypeSaleDto> Handle(GetTypeSaleByIdQuery query, CancellationToken cancellationToken)
        {
            var typeSales = await _typeSaleRepository.GetAllAsync();
            var typeSale = typeSales.FirstOrDefault(x => x.Id == query.Id);

            if (typeSale == null) throw new Exception("Type Sale Not Found");
            return _mapper.Map<TypeSaleDto>(typeSale);
        }
    }
}
