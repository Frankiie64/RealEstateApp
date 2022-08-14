using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Improvement;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Improvements.Commands.CreateImprovement
{
    public class CreateImprovementCommand : CreateImprovementDto, IRequest<int>
    {
    }
    public class CreateImprovementCommandHandler : IRequestHandler<CreateImprovementCommand, int>
    {
        private readonly IImprovementRepository _improvementRepository;
        private readonly IMapper _mapper;

        public CreateImprovementCommandHandler(IImprovementRepository improvementRepository, IMapper mapper)
        {
            _improvementRepository = improvementRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateImprovementCommand request, CancellationToken cancellationToken)
        {
            var improvement = _mapper.Map<Improvement>(request);
            await _improvementRepository.createAsync(improvement);
            return improvement.Id;
        }
    }
}

