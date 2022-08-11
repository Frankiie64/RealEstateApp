using RealEstateApp.Core.Application.Dtos.Account;
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
        Task<UserVM> GetUserByIdAsync(string id);
        Task<RegisterResponse> UpdateAsync(SaveUserVM vm, ResetPasswordVM vmPass);

        Task<RegisterResponse> UpdateAgentAsync(SaveUserVM vm);

        Task SignOutAsync();
    }
}