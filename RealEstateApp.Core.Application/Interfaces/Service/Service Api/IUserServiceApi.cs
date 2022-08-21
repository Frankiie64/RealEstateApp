using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Interfaces.Service.Service_Api
{
    public interface IUserServiceApi
    {
        Task<AuthenticationResponse> LoginAsync(LoginVM vm);
        Task<RegisterResponse> RegisterAsync(SaveUserVM vm, string origin);

    }
}
