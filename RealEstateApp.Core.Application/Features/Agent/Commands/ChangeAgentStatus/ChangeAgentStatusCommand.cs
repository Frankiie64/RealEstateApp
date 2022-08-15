using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Agent.Commands.ChangeAgentStatus
{
    public class ChangeAgentStatusCommand : IRequest<AgentChangeStatusResponse>
    {
        public string Id { get; set; }
        [JsonIgnore]
        public string Firstname { get; set; }
        [JsonIgnore]
        public string Lastname { get; set; }
        [JsonIgnore]
        public string DocumementId { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        [JsonIgnore]
        public string Username { get; set; }
        [JsonIgnore]
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public List<string> Roles { get; set; }
        [JsonIgnore]
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public int PropertiesQuantity { get; set; }
    }

    public class ChangeAgentStatusCommandHandler : IRequestHandler<ChangeAgentStatusCommand, AgentChangeStatusResponse>
    {
        private readonly IAccountServices _accountServices;
        private readonly IUserService _userServices;

        private readonly IMapper _mapper;

        public ChangeAgentStatusCommandHandler(IAccountServices accountServices, IMapper mapper, IUserService userServices)
        {
            _accountServices = accountServices;
            _mapper = mapper;
            _userServices = userServices;
        }

        public async Task<AgentChangeStatusResponse> Handle(ChangeAgentStatusCommand command, CancellationToken cancellationToken)
        {

            var allUsers = await _userServices.GetAllUsersAsync();

            var agent = allUsers.FirstOrDefault(x => x.Id == command.Id);
            if (agent == null) throw new Exception($"Agent Not Found.");

            command.Id = agent.Id;
            command.Firstname = agent.Firstname;
            command.PhoneNumber = agent.PhoneNumber;
            command.Lastname = agent.Lastname;
            command.DocumementId = agent.DocumementId;
            command.Email = agent.Email;
            command.Username = agent.Username;

            await _accountServices.ChangeStatusAsync(_mapper.Map<RegisterRequest>(command));

            var changeStatusDto = _mapper.Map<AgentChangeStatusResponse>(command);

            return changeStatusDto;
        }
    }
}
