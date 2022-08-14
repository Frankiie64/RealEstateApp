using AutoMapper;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Services;
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
        public async Task<RegisterResponse>  RegisterAsync(SaveUserVM vm, string origin)
        {
            RegisterRequest registerRequest = mapper.Map<RegisterRequest>(vm);
            return await accountServices.RegisterUserAsync(registerRequest, origin);
        }
        public async Task<RegisterResponse> UpdateAsync(SaveUserVM vm,string id)
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
            var items = mapper.Map<List<UserVM>>( await accountServices.GetAllUsersAsync());
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

        public async Task<RegisterResponse> UpdateAgentAsync(SaveUserVM vm)
        {
            RegisterRequest registerRequest = mapper.Map<RegisterRequest>(vm);
            return await accountServices.UpdateAgentAsync(registerRequest);
        }

        public async Task<List<UserVM>> GetAllAgentAsync()
        {

            List<UserVM> items = mapper.Map<List<UserVM>>(await accountServices.GetAllUsersAsync());

            items = items.Where(clients => clients.Roles[0] == Roles.Agent.ToString()).ToList();
            return items;
            
        }
    }
}
