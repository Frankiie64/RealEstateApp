using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Dtos.Agent;
using RealEstateApp.Core.Application.ViewModels.Agent;
using RealEstateApp.Core.Application.ViewModels.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPassWordResponse> ForgotPasswordAsync(ForgotPasswordVM vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginVM vm);
        Task<RegisterResponse> RegisterAsync(SaveUserVM vm,string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordVM vm);
        Task<List<UserVM>> GetAllUsersAsync();
        Task<List<UserVM>> GetAllClientsAsync();
        Task<List<AgentVM>> GetAllAgentAsync();
        Task<List<UserVM>> GetAllAdminAsync();
        Task<List<UserVM>> GetAllDevelopersAsync();
        Task<UserVM> GetUserByIdAsync(string id);
        Task<RegisterResponse> UpdateAsync(SaveUserVM vm,string id);
        Task<RegisterResponse> ChangeStatus(AgentDto vm, string id);

        Task SignOutAsync();
        Task<AuthenticationResponse> IsActive(string id);
        Task<RegisterResponse> DeleteUserAsync(string id);
    }
}