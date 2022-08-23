using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels;
using RealEstateApp.Core.Application.ViewModels.Users;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _context;
        private readonly IMapper _mapper;
        AuthenticationResponse _user;

        public AdminController(IUserService userService, IHttpContextAccessor context, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
            _context = context;
            _user = _context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Admins = await _userService.GetAllAdminAsync();
            return View(new UserVM());
        }

        public IActionResult Create()
        {
            return View("SaveAdmin", new SaveUserGenericVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUserGenericVM vm)
        {
            var viewModel = _mapper.Map<SaveUserVM>(vm);

            viewModel.Rol = Roles.SuperAdmin.ToString();

            if (!ModelState.IsValid)
            {
                return View("SaveAdmin", vm);
            }

            var origin = Request.Headers["origin"];
            RegisterResponse response = await _userService.RegisterAsync(viewModel, origin);

            if (response.HasError)
            {
                viewModel.HasError = response.HasError;
                viewModel.Error = response.Error;
            }

            return RedirectToRoute(new { controller = "Admin", action = "Index" });
        }


        public async Task<IActionResult> IsActive(UserVM vm)
        {
            if (vm.Id == _user.Id)
            {
                return RedirectToRoute(new { controller = "User", action = "AccessDenied" });
            }
            await _userService.IsActive(vm.Id);

            return RedirectToRoute
                (new { controller = "Admin", action = "Index" });
        }


        public async Task<IActionResult> Update(string id)
        {
            if (id == _user.Id)
            {
                return RedirectToRoute(new { controller = "User", action = "AccessDenied" });
            }

            var adminUser = _mapper.Map<SaveUserGenericVM>(await _userService.GetUserByIdAsync(id));
            return View("SaveAdmin", adminUser);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveUserGenericVM vm)
        {
            var viewModel = _mapper.Map<SaveUserVM>(vm);

            if (!ModelState.IsValid)
            {
                return View("SaveAdmin", vm);
            }

            RegisterResponse response = await _userService.UpdateAsync(viewModel, viewModel.Id);

            if (response.HasError)
            {
                viewModel.HasError = response.HasError;
                viewModel.Error = response.Error;
                return View("SaveAdmin", vm);
            }
            return RedirectToRoute(new { controller = "Admin", action = "Index" });
        }



    }
}
