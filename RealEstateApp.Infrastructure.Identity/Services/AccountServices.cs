using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Dtos.Email;
using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using RealEstateApp.Core.Domain.Settings;
using Microsoft.Extensions.Options;

namespace RealEstateApp.Infrastructure.Identity.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signManager;
        private readonly IEmailService emailService;

        public AccountServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager, IEmailService emailService)
        {
            this.userManager = userManager;
            this.signManager = signManager;
            this.emailService = emailService;
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
            response.PhotoProfileUrl = user.PhotoProfileUrl;

            var rolesList = await userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;

            return response;
        }

        public async Task SignOutAsync()
        {
            await signManager.SignOutAsync();
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
                user.IsActive = true;
                user.EmailConfirmed = true;
            }
            if (request.Rol == Roles.Admin.ToString())
            {
                user.IsActive = true;
                user.EmailConfirmed = true;
            }

            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, request.Rol);

                var url = await SendVerificationEmailUrl(user, origin);

                if (request.Rol == Roles.Client.ToString())
                {
                    await emailService.SendAsync(new EmailRequest()
                    {
                        To = user.Email,
                        Body = $"Por favor confirma tu cuenta, mediante la visita de este link. \n \n {url}",
                        Subject = "Confirmar nuevo usuario"
                    });
                }

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
        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return "No se ha registrado ningun usuario con este correo.";
            }

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return $"La cuenta ha sido confirmada para el correo de {user.Email}. Ahora puede utilizar nuestra aplicacion.";
            }
            else
            {
                return $"Ha ocurrido un error tratando de validar el correo {user.Email}.";
            }
        }

        public async Task<ForgotPassWordResponse> ForgotPasswordRequestAsync(ForgotPassowordRequest request, string origin)
        {
            ForgotPassWordResponse response = new();
            response.HasError = false;

            var account = await userManager.FindByEmailAsync(request.Email);

            if (account == null)
            {
                response.HasError = true;
                response.Error = $"La cuenta {request.Email} no se encuentra registrada.";
                return response;
            }

            var rolList = await userManager.GetRolesAsync(account);

            if (rolList.Any(r => r != Roles.Client.ToString()))
            {
                response.HasError = true;
                response.Error = $"Esta opcion solo esta disponible para usuario tipo clientes.";
                return response;
            }
            var url = await SendForgotPasswordVerificationEmailUrl(account, origin);

            await emailService.SendAsync(new EmailRequest()
            {
                To = request.Email,
                Body = $"Por favor entra en este link para el cambio de contraseña, mediante la visita de este link. {url}",
                Subject = "Recuperar contraseña"
            });

            response.Url = url;

            return response;
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            ResetPasswordResponse response = new();
            response.HasError = false;

            var account = await userManager.FindByEmailAsync(request.Email);

            if (account == null)
            {
                response.HasError = true;
                response.Error = $"La cuenta {request.Email} no se encuentra registrada.";
                return response;
            }

            request.Token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));

            var result = await userManager.ResetPasswordAsync(account, request.Token, request.Password);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Ha ocurrido un error reseteando la contraseña";
                return response;

            }
            return response;
        }


        private async Task<string> SendVerificationEmailUrl(ApplicationUser user, string origin)
        {
            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var route = "User/ConfirmEmail";

            var url = new Uri(string.Concat($"{origin}/", route));
            var verificationUrl = QueryHelpers.AddQueryString(url.ToString(), "userId", user.Id);
            verificationUrl = QueryHelpers.AddQueryString(verificationUrl, "token", code);

            return verificationUrl;
        }
        private async Task<string> SendForgotPasswordVerificationEmailUrl(ApplicationUser user, string origin)
        {
            var code = await userManager.GeneratePasswordResetTokenAsync(user);

            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var route = "User/ResetPassword";

            var url = new Uri(string.Concat($"{origin}/", route));
            var verificationUrl = QueryHelpers.AddQueryString(url.ToString(), "token", code);

            return verificationUrl;
        }

        public async Task<List<AuthenticationResponse>> GetAllUsersAsync()
        {
            var items = await userManager.Users.ToListAsync();

            List<AuthenticationResponse> list = new();

            foreach (var vm in items)
            {

                var rol = await userManager.GetRolesAsync(vm).ConfigureAwait(false);

                AuthenticationResponse item = new AuthenticationResponse
                {

                    Id = vm.Id,
                    Firstname = vm.Firstname,
                    Lastname = vm.Lastname,
                    DocumementId = vm.DocumementId,
                    Username = vm.UserName,
                    Email = vm.Email,
                    Roles = rol.ToList(),
                    IsVerified = vm.EmailConfirmed,
                    PhoneNumber = vm.PhoneNumber,
                    PhotoProfileUrl = vm.PhotoProfileUrl,
                    IsActive = vm.IsActive,
                };

                list.Add(item);
            };

            return list;
        }
        public async Task<AuthenticationResponse> GetUserByIdAsync(string id)
        {
            var vm = await userManager.FindByIdAsync(id);

            if (vm == null) throw new Exception("No se ha encontrado ningun usuario con este Id");

            var rol = await userManager.GetRolesAsync(vm).ConfigureAwait(false);

            AuthenticationResponse item = new AuthenticationResponse
            {
                Id = vm.Id,
                Roles = rol.ToList(),
                Firstname = vm.Firstname,
                Lastname = vm.Lastname,
                Username = vm.UserName,
                DocumementId = vm.DocumementId,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                PhotoProfileUrl = vm.PhotoProfileUrl,
                IsActive = vm.IsActive

            };

            return item;
        }



        public async Task<AuthenticationResponse> IsActive(string id)
        {
            var vm = await userManager.FindByIdAsync(id);

            var rol = await userManager.GetRolesAsync(vm).ConfigureAwait(false);


            vm.IsActive = vm.IsActive == true ? false : true;

            await userManager.UpdateAsync(vm);

            AuthenticationResponse item = new AuthenticationResponse
            {
                Id = vm.Id,
                Firstname = vm.Firstname,
                Lastname = vm.Lastname,
                Username = vm.UserName,
                DocumementId = vm.DocumementId,
                Email = vm.Email,
                Roles = rol.ToList(),
                IsActive = vm.IsActive
            };

            return item;

        }


        public async Task<RegisterResponse> UpdateUserAsync(RegisterRequest request)
        {
            RegisterResponse response = new();
            response.HasError = false;

            var user = await userManager.FindByIdAsync(request.Id);

            var userWithUsername = await userManager.FindByNameAsync(request.Username);

            if (userWithUsername != null && request.Username != request.Username)
            {
                response.HasError = true;
                response.Error = $"El nombre de usuario '{request.Username}' ya fue creado.";
                return response;
            }

            var userWithEmail = await userManager.FindByEmailAsync(request.Email);

            if (userWithEmail != null && request.Email != request.Email)
            {
                response.HasError = true;
                response.Error = $"El email '{request.Email}' ya fue registrado.";
                return response;
            }

            user.Email = request.Email;
            user.Firstname = request.Firstname;
            user.Lastname = request.Lastname;
            user.DocumementId = request.DocumementId;
            user.UserName = request.Username;
            user.PhoneNumber = request.PhoneNumber;
            user.PhoneNumberConfirmed = true;
            user.PhotoProfileUrl = request.PhotoProfileUrl;


            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Ha ocurrido un error actualizando el usuario";
                return response;
            }

            response.IdUser = user.Id;

            return response;
        }
        public async Task<RegisterResponse> ChangeStatusAsync(RegisterRequest request)
        {
            RegisterResponse response = new();
            response.HasError = false;

            var user = await userManager.FindByIdAsync(request.Id);

            user.IsActive = user.IsActive == true ? false : true;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = "Ha ocurrido algun problema cuando se intento cambiar el estado del usuario.";
            }
            return response;

        }

        public async Task<RegisterResponse> DeleteUser(string id)
        {
            RegisterResponse response = new();
            response.HasError = false;

            var user = await userManager.FindByIdAsync(id);

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = "Ocurrio un problema eliminando este usuario";
            }

            return response;

        }
    }
}
