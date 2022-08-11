using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Core.Application.Interfaces.Services;
using System.Threading.Tasks;

namespace WebAPI.RealEstateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _accountService;
        private readonly IMapper mapper;
        public AccountController(IAccountServices accountService,IMapper mapper)
        {
            _accountService = accountService;
            this.mapper = mapper;
        }



        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticationAsync(request));
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            request.Rol = Roles.Admin.ToString();
            return Ok(await _accountService.RegisterUserAsync(request, origin));
        }

        [HttpPost("RegisterDeveloper")]
        public async Task<IActionResult> RegisterDeveloperAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            request.Rol = Roles.Developer.ToString();
            return Ok(await _accountService.RegisterUserAsync(request, origin));
        }
      
    }
}
