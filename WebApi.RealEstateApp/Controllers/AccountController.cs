using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }

            var response = await _accountService.AuthenticationAsync(request);
            if (response.HasError)
            {
                return NotFound(response.Error);
            }
            return Ok(response);
        }        
        [HttpGet("confirm-email")]
        public async Task<IActionResult> RegisterAsync([FromQuery] string userId, [FromQuery] string token)
        {
            return Ok(await _accountService.ConfirmEmailAsync(userId, token));
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPassowordRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.ForgotPasswordRequestAsync(request, origin));
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            return Ok(await _accountService.ResetPasswordAsync(request));
        }
    }
}
