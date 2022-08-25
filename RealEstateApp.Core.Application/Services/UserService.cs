using AutoMapper;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Dtos.Agent;
using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Core.Application.Interfaces.Repository;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.Agent;
using RealEstateApp.Core.Application.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountServices accountServices;

        private readonly IMapper mapper;

        public UserService(IAccountServices accountServices, IMapper mapper)
        {
            this.accountServices = accountServices;
            this.mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginVM vm)
        {
            AuthenticationRequest LoginRequest = mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse response = await accountServices.AuthenticationAsync(LoginRequest);

            return response;
        }
        public async Task SignOutAsync()
        {
            await accountServices.SignOutAsync();
        }
        public async Task<RegisterResponse> RegisterAsync(SaveUserVM vm, string origin)
        {
            RegisterRequest registerRequest = mapper.Map<RegisterRequest>(vm);
            return await accountServices.RegisterUserAsync(registerRequest, origin);
        }
        public async Task<RegisterResponse> UpdateAsync(SaveUserVM vm, string id)
        {
            RegisterRequest registerRequest = mapper.Map<RegisterRequest>(vm);
            registerRequest.Id = id;
            return await accountServices.UpdateUserAsync(registerRequest);
        }
        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await accountServices.ConfirmEmailAsync(userId, token);
        }
        public async Task<ForgotPassWordResponse> ForgotPasswordAsync(ForgotPasswordVM vm, string origin)
        {
            ForgotPassowordRequest forgotRequest = mapper.Map<ForgotPassowordRequest>(vm);
            return await accountServices.ForgotPasswordRequestAsync(forgotRequest, origin);
        }
        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordVM vm)
        {
            ResetPasswordRequest resetRequest = mapper.Map<ResetPasswordRequest>(vm);
            return await accountServices.ResetPasswordAsync(resetRequest);
        }
        public async Task<List<UserVM>> GetAllUsersAsync()
        {
            var items = mapper.Map<List<UserVM>>(await accountServices.GetAllUsersAsync());
            return items;
        }
        public async Task<List<UserVM>> GetAllClientsAsync()
        {
            List<UserVM> items = mapper.Map<List<UserVM>>(await accountServices.GetAllUsersAsync());

            items = items.Where(clients => clients.Roles[0] == Roles.Client.ToString()).ToList();

            return items;
        }

        public async Task<UserVM> GetUserByIdAsync(string id)
        {
            return mapper.Map<UserVM>(await accountServices.GetUserByIdAsync(id));
        }

        public async Task<RegisterResponse> ChangeStatus(AgentDto vm, string id)
        {
            RegisterRequest registerRequest = mapper.Map<RegisterRequest>(vm);
            registerRequest.Id = id;
            return await accountServices.ChangeStatusAsync(registerRequest);
        }

        public async Task<List<AgentVM>> GetAllAgentAsync()
        {

            List<AgentVM> items = mapper.Map<List<AgentVM>>(await accountServices.GetAllUsersAsync());

            return items.Where(clients => clients.Roles[0] == Roles.Agent.ToString()).Select(agent => new AgentVM
            {
                Id = agent.Id,
                Firstname = agent.Firstname,
                Lastname = agent.Lastname,
                Username = agent.Username,
                DocumementId = agent.DocumementId,
                PhotoProfileUrl = agent.PhotoProfileUrl,
                PhoneNumber = agent.PhoneNumber,
                Email = agent.Email,
                IsActive = agent.IsActive,
            }).ToList();


        }

        public async Task<List<UserVM>> GetAllAdminAsync()
        {
            List<UserVM> admins = new();
            List<UserVM> users = mapper.Map<List<UserVM>>(await accountServices.GetAllUsersAsync());
            var superAdm = users.Where(clients => clients.Roles[0] == Roles.SuperAdmin.ToString()).ToList();

            foreach (var superAdmin in superAdm)
            {
                admins.Add(superAdmin);
            }

            var adm = users.Where(clients => clients.Roles[0] == Roles.Admin.ToString()).ToList();

            foreach (var admin in adm)
            {
                admins.Add(admin);
            }

            return admins;
        }
        public async Task<List<UserVM>> GetAllDevelopersAsync()
        {
            List<UserVM> items = mapper.Map<List<UserVM>>(await accountServices.GetAllUsersAsync());

            items = items.Where(clients => clients.Roles[0] == Roles.Developer.ToString()).ToList();
            return items;
        }

        public async Task<AuthenticationResponse> IsActive(string id)
        {
            return await accountServices.IsActive(id);
        }

        public async Task<RegisterResponse> DeleteUserAsync(string id)
        {
            var user = await accountServices.GetUserByIdAsync(id);
            return await accountServices.DeleteUser(user.Id);

        }
    }
}
