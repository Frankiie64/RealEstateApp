using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Agent;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Agent.Queries.GetAgentById
{
    public class GetAgentByIdQuery : IRequest<IEnumerable<AgentDto>>
    {
        public string Id { get; set; }
    }

    public class GetAgentByIdQueryHandler : IRequestHandler<GetAgentByIdQuery, IEnumerable<AgentDto>>
    {
        private readonly IAccountServices _accountServices;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetAgentByIdQueryHandler(IAccountServices accountServices, IMapper mapper, IPropertyRepository propertyRepository)
        {
            _accountServices = accountServices;
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AgentDto>> Handle(GetAgentByIdQuery query, CancellationToken cancellationToken)
        {
            return await GetAllAgentDto(query.Id);
        }


        private async Task<List<AgentDto>> GetAllAgentDto(string agentId)
        {

            var agents = await _accountServices.GetAllUsersAsync();
            var  agent = await _accountServices.GetUserByIdAsync(agentId);
            //if (agent == null) throw new Exception($"El Agente que estas intentando buscar no existe");

         
            var properties = await _propertyRepository.GetAllAsync();

            return agents.Where(agent => agent.Roles[0] == "Agent" && agent.Id == agentId).Select(agent => new AgentDto
            {
                Id = agent.Id,
                Firstname = agent.Firstname,
                Lastname = agent.Lastname,
                Email = agent.Email,
                PhoneNumber = agent.PhoneNumber,
                IsActive = agent.IsActive,
                PropertiesQuantity = properties.Where(property => property.AgentId == agent.Id).Count()
            }).ToList();
        }
    }
}
