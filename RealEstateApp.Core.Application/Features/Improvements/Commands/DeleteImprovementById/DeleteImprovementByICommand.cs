using MediatR;
using RealEstateApp.Core.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Improvements.Commands.DeleteImprovementById
{
    public class DeleteImprovementByICommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteImprovementByICommandHandler : IRequestHandler<DeleteImprovementByICommand, int>
    {
        private readonly IImprovementRepository _improvementRepository;

        public DeleteImprovementByICommandHandler(IImprovementRepository improvementRepository)
        {
            _improvementRepository = improvementRepository;
        }

        public async Task<int> Handle(DeleteImprovementByICommand command, CancellationToken cancellationToken)
        {
            var improvement = await _improvementRepository.GetByIdAsync(command.Id);
            if (improvement == null) throw new Exception($"Improvement Not Found.");
            await _improvementRepository.DeleteAsync(improvement);
            return improvement.Id;
        }
    }
}
