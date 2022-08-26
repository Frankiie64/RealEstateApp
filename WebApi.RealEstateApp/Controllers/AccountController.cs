using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Core.Application.Interfaces.Service.Service_Api;
using RealEstateApp.Core.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using System.Threading.Tasks;

namespace WebAPI.RealEstateApp.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Sistema de Membresias")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceApi _accountService;
        private readonly IMapper mapper;
        public AccountController(IAccountServiceApi accountService, IMapper mapper)
        {
            _accountService = accountService;
            this.mapper = mapper;
        }


        [HttpPost("authenticate")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Iniciar Session ",
            Description = "Iniciar Session como Administrador o Desarrollador"
         )]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticationAsync(request));
        }


        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost("RegisterAdmin")]
        //[Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Registrar un nuevo Administrador",
            Description = "Recibe los parametros para crear un usuario con el Rol Administrador"
         )]
        public async Task<IActionResult> RegisterAdminAsync([FromBody]RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            request.Rol = Roles.SuperAdmin.ToString();
            return Ok(await _accountService.RegisterUserAsync(request, origin));
        }



        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost("RegisterDeveloper")]
        //[Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
            Summary = "Registrar un nuevo Desarrollador",
            Description = "Recibe los parametros para crear un usuario con el Rol Desarrollador"
         )]
        public async Task<IActionResult> RegisterDeveloperAsync([FromBody]RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            request.Rol = Roles.Developer.ToString();
            return Ok(await _accountService.RegisterUserAsync(request, origin));
        }

    }
}
