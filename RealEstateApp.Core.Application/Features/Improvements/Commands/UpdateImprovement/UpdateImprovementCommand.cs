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

namespace RealEstateApp.Core.Application.Features.Improvements.Commands.UpdateImprovement
{
    public class UpdateImprovementCommand : SaveImprovementDto, IRequest<ImprovementUpdateResponse>
    {
    }

    public class UpdateImprovementCommandHandler : IRequestHandler<UpdateImprovementCommand, ImprovementUpdateResponse>
    {
        private readonly IImprovementRepository _improvementRepository;
        private readonly IMapper _mapper;
        public UpdateImprovementCommandHandler(IImprovementRepository improvementRepository, IMapper mapper)
        {
            _improvementRepository = improvementRepository;
            _mapper = mapper;
        }

        public async Task<ImprovementUpdateResponse> Handle(UpdateImprovementCommand command, CancellationToken cancellationToken)
        {
            var improvement = await _improvementRepository.GetByIdAsync(command.Id);

            if (improvement == null)
            {
                throw new Exception($"Improvement Not Found.");
            }
            else
            {
                improvement = _mapper.Map<Improvement>(command);
                await _improvementRepository.UpdateAsync(improvement, improvement.Id);
                var improvementDto = _mapper.Map<ImprovementUpdateResponse>(improvement);

                return improvementDto;
            }
        }
    }
}
