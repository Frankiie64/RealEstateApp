using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Improvement;
using RealEstateApp.Core.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Improvements.Queries.GetAllImprovements
{
    public class GetAllImprovementsQuery : IRequest<IEnumerable<ImprovementDto>>
    {
    }

    public class GetAllImprovementsQueryHandler : IRequestHandler<GetAllImprovementsQuery, IEnumerable<ImprovementDto>>
    {
        private readonly IImprovementRepository _improvementRepository;
        private readonly IMapper _mapper;

        public GetAllImprovementsQueryHandler(IImprovementRepository improvementRepository, IMapper mapper)
        {
            _improvementRepository = improvementRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ImprovementDto>> Handle(GetAllImprovementsQuery query, CancellationToken cancellationToken)
        {
            var ImprovementDto =  await GetAllDto();
            return ImprovementDto;
        }

        private async Task<List<ImprovementDto>> GetAllDto()
        {
            var improvementList = await _improvementRepository.GetAllAsync();

            return _mapper.Map<List<ImprovementDto>>(improvementList);
        }
    }
}
