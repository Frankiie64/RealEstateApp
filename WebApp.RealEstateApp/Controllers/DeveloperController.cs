using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class DeveloperController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _context;
        private readonly IMapper _mapper;
        AuthenticationResponse _user;

        public DeveloperController(IUserService userService, IHttpContextAccessor context, IMapper mapper)
        {
            _userService = userService;
            _context = context;
            _mapper = mapper;
            _user = _context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Developers = await _userService.GetAllDevelopersAsync();
            return View(new UserVM());
        }

        public IActionResult Create()
        {
            return View("SaveDeveloper", new SaveUserGenericVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUserGenericVM vm)
        {
            var viewModel = _mapper.Map<SaveUserVM>(vm);

            viewModel.Rol = Roles.Developer.ToString();

            if (!ModelState.IsValid)
            {
                return View("SaveDeveloper", vm);
            }

            var origin = Request.Headers["origin"];
            RegisterResponse response = await _userService.RegisterAsync(viewModel, origin);

            if (response.HasError)
            {
                viewModel.HasError = response.HasError;
                viewModel.Error = response.Error;
            }

            return RedirectToRoute(new { controller = "Developer", action = "Index" });
        }


        public async Task<IActionResult> IsActive(UserVM vm)
        {
            if (vm.Id == _user.Id)
            {
                return RedirectToRoute(new { controller = "User", action = "AccessDenied" });
            }
            await _userService.IsActive(vm.Id);

            return RedirectToRoute
                (new { controller = "Developer", action = "Index" });
        }


        public async Task<IActionResult> Update(string id)
        {
            if (_user == null|| id == _user.Id)
            {
                return RedirectToRoute(new { controller = "User", action = "AccessDenied" });
            }

            var adminUser = _mapper.Map<SaveUserGenericVM>(await _userService.GetUserByIdAsync(id));
            return View("SaveDeveloper", adminUser);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveUserGenericVM vm)
        {
            var viewModel = _mapper.Map<SaveUserVM>(vm);

            if (!ModelState.IsValid)
            {
                return View("SaveDeveloper", vm);
            }

            RegisterResponse response = await _userService.UpdateAsync(viewModel, viewModel.Id);

            if (response.HasError)
            {
                viewModel.HasError = response.HasError;
                viewModel.Error = response.Error;
                return View("SaveDeveloper", vm);
            }
            return RedirectToRoute(new { controller = "Developer", action = "Index" });
        }


    }
}
