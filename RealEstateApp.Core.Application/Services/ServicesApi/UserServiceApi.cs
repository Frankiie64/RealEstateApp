using AutoMapper;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Interfaces.Service.Service_Api;
using RealEstateApp.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Services.ServicesApi
{
    public class UserServiceApi : IUserServiceApi
    {
        private readonly IAccountServiceApi accountServices;
        private readonly IMapper mapper;

        public UserServiceApi(IAccountServiceApi accountServices, IMapper mapper)
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

        public async Task<RegisterResponse> RegisterAsync(SaveUserVM vm, string origin)
        {
            RegisterRequest registerRequest = mapper.Map<RegisterRequest>(vm);
            return await accountServices.RegisterUserAsync(registerRequest, origin);
        }
    }
}
