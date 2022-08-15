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

namespace RealEstateApp.Core.Application.Features.Agent.Queries.GetAllAgents
{
    public class GetAllAgentsQuery : IRequest<IEnumerable<AgentDto>>
    {
    }

    public class GetAllAgentsQueryHandler : IRequestHandler<GetAllAgentsQuery, IEnumerable<AgentDto>>
    {
        private readonly IAccountServices _accountServices;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetAllAgentsQueryHandler(IAccountServices accountServices, IPropertyRepository propertyRepository, IMapper mapper)
        {
            _accountServices = accountServices;
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgentDto>> Handle(GetAllAgentsQuery query, CancellationToken cancellationToken)
        {
            return await GetAllDto();
        }

        private async Task<List<AgentDto>> GetAllDto()
        {
            List<AgentDto> agentList =  _mapper.Map<List<AgentDto>>(await _accountServices.GetAllUsersAsync());
            var properties = await _propertyRepository.GetAllAsync();

            return agentList.Where(agent => agent.Roles[0] == "Agent").Select(agent => new AgentDto
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

