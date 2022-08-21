using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.RealEstateApp.middlewares;
using RealEstateApp;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.RealEstateApp.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult Index()
        {            
            return View(new LoginVM());
        }
        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            AuthenticationResponse userVm = await userService.LoginAsync(vm);
            if (userVm!=null && userVm.HasError != true)
            {
                HttpContext.Session.Set<AuthenticationResponse>("user", userVm);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                vm.HasError = userVm.HasError;
                vm.Error = userVm.Error;
                return View(vm);
            }            
        }
        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult Register()
        {            
            return View(new SaveUserVM());
        }
        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> Register(SaveUserVM vm)
        {
            vm.HasError = false;
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var origin = Request.Headers["origin"];

            RegisterResponse response = await userService.RegisterAsync(vm,origin);

            if (response.HasError)
            {
                vm.HasError = true;
                vm.Error = response.Error;
                return View(vm);

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(response.IdUser))
                {
                    vm.PhotoProfileUrl = Photo.Upload(vm.file, "User", response.IdUser);

                    await userService.UpdateAsync(vm,response.IdUser);
                }

                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await userService.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
       
        [ServiceFilter(typeof(LoginAuthorize))]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            string response = await userService.ConfirmEmailAsync(userId, token);
            return View("ConfirmEmail", response);
        }
        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordVM());
        }
        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var origin = Request.Headers["origin"];
            ForgotPassWordResponse response = await userService.ForgotPasswordAsync (vm, origin);

            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult ResetPassword(string token)
        {
            return View(new ResetPasswordVM { Token = token });
        }
        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> ResetPasswordPost(ResetPasswordVM vm)
        {

            if (!ModelState.IsValid)
            {
                return View("ResetPassword",vm);
            }

            ResetPasswordResponse response = await userService.ResetPasswordAsync(vm);

            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View("ResetPassword", vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
        public IActionResult AccessDenied()
        {
            return View();            
        }

    }
}
