using AutoMapper;
using MediatR;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Agent.Commands.ChangeAgentStatus
{
    public class ChangeAgentStatusCommand : IRequest<AgentChangeStatusResponse>
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DocumementId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public string PropertiesQuantity { get; set; }
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
            //AuthenticationResponse

            var allUsers = await _userServices.GetAllUsersAsync();
            var Agent = allUsers.Where(x => x.Id == command.Id).ToList();

            foreach (var agentUser in Agent)
            {
                command.Id = agentUser.Id;
                command.Firstname = agentUser.Firstname;
                //agent.PhoneNumber = command.PhoneNumber;
                command.Lastname = agentUser.Lastname;
                command.DocumementId = agentUser.DocumementId;
                command.Email = agentUser.Email;
                command.Username = agentUser.Username;
            }

            var changeStatus = await _userServices.GetUserByIdAsync(command.Id);
            if (changeStatus == null) throw new Exception($"Improvement Not Found.");

            //AuthenticationResponse agent = new();
            //agent.Id = command.Id;
            //agent.Firstname = command.Firstname;
            ////agent.PhoneNumber = command.PhoneNumber;
            //agent.Lastname = command.Lastname;
            //agent.DocumementId = command.DocumementId;
            //agent.Email = command.Email;
            //agent.Username = command.Username;

            ResetPasswordRequest pass = new();
            changeStatus = _mapper.Map<UserVM>(command);
            //var mapping = _mapper.Map<RegisterRequest>(agent);
            await _accountServices.UpdateAgentAsync(_mapper.Map<RegisterRequest>(command));

            //var changeStatusDto = _mapper.Map<AgentChangeStatusResponse>(changeStatus);
            var changeStatusDto = _mapper.Map<AgentChangeStatusResponse>(command);

            return changeStatusDto;
        }
    }
}
