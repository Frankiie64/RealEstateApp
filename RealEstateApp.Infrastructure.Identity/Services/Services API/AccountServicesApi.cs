using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Core.Application.Interfaces.Service.Service_Api;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Domain.Settings;
using RealEstateApp.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace RealEstateApp.Infrastructure.Identity.Services.Services_API
{
    public class AccountServicesApi : IAccountServiceApi
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signManager;
        private readonly JWTSettings _jwtSettings;


        public AccountServicesApi(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager, IOptions<JWTSettings> jwtSettings)
        {
            this.userManager = userManager;
            this.signManager = signManager;
            _jwtSettings = jwtSettings.Value;
        }


        public async Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest request)
        {

            AuthenticationResponse response = new();


            var user = await userManager.FindByEmailAsync(request.Name);

            if (user == null)
            {
                user = await userManager.FindByNameAsync(request.Name);
            }

            if (user == null)
            {
                response.HasError = true;
                response.Error = $"La cuenta {request.Name} no se encuentra registrada.";
                return response;
            }

            var result = await signManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"La credenciales son incorrectas.";
                return response;
            }

            if (!user.EmailConfirmed)
            {
                response.HasError = true;
                response.Error = $"Confirme su correo.";
                return response;
            }

            if (!user.IsActive)
            {
                response.HasError = true;
                response.Error = $"Comuniquese con su administrador para acceder a los permisos de agente.";
                return response;
            }

            response.Id = user.Id;
            response.Email = user.Email;
            response.Username = user.UserName;
            response.Firstname = user.Firstname;
            response.Lastname = user.Lastname;
            response.DocumementId = user.DocumementId;
            response.IsActive = user.IsActive;

            var rolesList = await userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;


            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

            response.JWTtoken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refreshToken = GenerateRefreshToken();
            response.RefreshToken = refreshToken.Token;

            return response;
        }


        public async Task<RegisterResponse> RegisterUserAsync(RegisterRequest request, string origin)
        {
            RegisterResponse response = new();
            response.HasError = false;

            var userWithUsername = await userManager.FindByNameAsync(request.Username);

            if (userWithUsername != null)
            {
                response.HasError = true;
                response.Error = $"El nombre de usuario '{request.Username}' ya fue creado.";
                return response;
            }

            var userWithEmail = await userManager.FindByEmailAsync(request.Email);

            if (userWithEmail != null)
            {
                response.HasError = true;
                response.Error = $"El email '{request.Email}' ya fue registrado.";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                DocumementId = request.DocumementId,
                UserName = request.Username,
                PhotoProfileUrl = request.PhotoProfileUrl,
                PhoneNumberConfirmed = true
            };

            if (request.Rol == Roles.Agent.ToString())
            {
                user.EmailConfirmed = true;
            }

            if (request.Rol == Roles.Client.ToString())
            {
                user.IsActive = true;
            }

            if (request.Rol == Roles.SuperAdmin.ToString())
            {
                user.EmailConfirmed = true;
                user.IsActive = true;
            }

            if (request.Rol == Roles.Developer.ToString())
            {
                user.EmailConfirmed = true;
                user.IsActive = true;
            }

            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, request.Rol);
            }
            else
            {
                response.HasError = true;
                response.Error = $"Por favor ingresé una contraseña que contega al menos 8 caracteres entre ellos, una mayúscula ,una minúscula, caracter especial y un número";
                return response;
            }

            var item = await userManager.FindByNameAsync(user.UserName);

            response.IdUser = item.Id;

            return response;
        }



        #region API AUTHENTICATION
        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user); //Claims = Permisos
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>(); //Agregar los roles a los claims

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //token unico
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmectricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredetials = new SigningCredentials(symmectricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurantionInMinutes),
                signingCredentials: signingCredetials);

            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var ramdomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(ramdomBytes);

            return BitConverter.ToString(ramdomBytes).Replace("-", "");
        }

        #endregion
    }
}
