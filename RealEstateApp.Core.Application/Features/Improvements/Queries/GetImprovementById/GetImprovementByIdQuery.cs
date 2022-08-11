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

namespace RealEstateApp.Core.Application.Features.Improvements.Queries.GetImprovementById
{
    public class GetImprovementByIdQuery : IRequest<ImprovementDto>
    {
        public int Id { get; set; }
    }

    public class GetImprovementByIdQueryHandler : IRequestHandler<GetImprovementByIdQuery, ImprovementDto>
    {
        private readonly IImprovementRepository _improvementRepository;
        private readonly IMapper _mapper;

        public GetImprovementByIdQueryHandler(IImprovementRepository improvementRepository, IMapper mapper)
        {
            _improvementRepository = improvementRepository;
            _mapper = mapper;
        }

        public async Task<ImprovementDto> Handle(GetImprovementByIdQuery query, CancellationToken cancellationToken)
        {
            var improvements = await _improvementRepository.GetAllAsync();
            var improvement = improvements.FirstOrDefault(w => w.Id == query.Id);
            if (improvement == null) throw new Exception($"Improvement Not Found.");
            var improvementDto = _mapper.Map<ImprovementDto>(improvement);
            return improvementDto;
        }
    }
}
