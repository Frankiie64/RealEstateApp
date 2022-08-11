using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Agent;
using RealEstateApp.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Agent.Queries.GetAgentById
{
    public class GetAgentByIdQuery : IRequest<AgentDto>
    {
        public string Id { get; set; }
    }

    public class GetAgentByIdQueryHandler : IRequestHandler<GetAgentByIdQuery, AgentDto>
    {
        private readonly IAccountServices _accountServices;
        private readonly IMapper _mapper;

        public GetAgentByIdQueryHandler(IAccountServices accountServices, IMapper mapper)
        {
            _accountServices = accountServices;
            _mapper = mapper;
        }
        public async Task<AgentDto> Handle(GetAgentByIdQuery query, CancellationToken cancellationToken)
        {
            var agents = await _accountServices.GetAllUsersAsync();
            agents = agents.Where(agent => agent.Roles[0] == "Admin").ToList();

            var agent = agents.FirstOrDefault(w => w.Id == query.Id);
            if (agent == null) throw new Exception($"Agent Not Found.");
            var agentDto = _mapper.Map<AgentDto>(agent);
            return agentDto;
        }
    }
}
