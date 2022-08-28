using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels;
using RealEstateApp.Core.Application.ViewModels.Improvement;
using RealEstateApp.Core.Application.ViewModels.Request;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using RealEstateApp.Core.Application.ViewModels.TypeSale;
using RealEstateApp.Core.Application.ViewModels.Users;
using System.Linq;
using System.Threading.Tasks;
using WebApp.RealEstateApp.Middlewares;

namespace WebApp.RealEstateApp.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImprovementService _improvementService;
        private readonly ITypeSaleService _typeSaleService;
        private readonly ITypePropertyService _typePropertyService;
        private readonly IHttpContextAccessor _context;
        private readonly IPropertyService _serviceProperty;
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        AuthenticationResponse _user;

        public AdminController(IUserService userService, IHttpContextAccessor context, IMapper mapper, IPropertyService serviceProperty,
            IRequestService requestService, IImprovementService improvementService, ITypeSaleService typeSaleService, ITypePropertyService typePropertyService)
        {
            _userService = userService;
            _serviceProperty = serviceProperty;
            _improvementService = improvementService;
            _typePropertyService = typePropertyService;
            _typeSaleService = typeSaleService;
            _mapper = mapper;
            _requestService = requestService;
            _context = context;
            _user = _context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        //Dashboard
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Dashboard(int id)
        {

            var properties = await _serviceProperty.GetAllViewModelWithIncludeAsync();
            var agents = await _userService.GetAllAgentAsync();
            var clients = await _userService.GetAllClientsAsync();
            var developers = await _userService.GetAllDevelopersAsync();


            DashboardViewModel dashBoard = new()
            {
                PropertiesQuantity = properties.Where(x => x.agent != null).Count(),
                AgentActive = agents.Where(agent => agent.IsActive == true).Count(),
                AgentDisabled = agents.Where(agent => agent.IsActive == false).Count(),
                ClientActive = clients.Where(client => client.IsActive == true).Count(),
                ClientDisabled = clients.Where(client => client.IsActive == false).Count(),
                DeveloperActive = developers.Where(dev => dev.IsActive == true).Count(),
                DeveloperDisabled = developers.Where(dev => dev.IsActive == false).Count()
            };

            return View("Dashboard", dashBoard);
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
        public async Task<IActionResult> Requests()
        {
           var requests = await _requestService.GetAllViewModelAsync();

            requests = requests.Where(x => x.Estado == false).ToList();

            ViewBag.Requests = requests;

            return View();
        }

        public async Task<IActionResult> CreateRequest(int Id)
        {
            var vm = await _requestService.GetByIdSaveViewModelAsync(Id);
            if (vm.Table == Tables.Improvements.ToString()) 
            {
                SaveImprovementViewModel request = new SaveImprovementViewModel
                {
                    Name = vm.Name,
                    Description = vm.Description
                };

                await _improvementService.CreateAsync(request);
            }
            if (vm.Table == Tables.TypeProperty.ToString()) 
            {
                SaveTypePropertyViewModel request = new SaveTypePropertyViewModel
                {
                    Name = vm.Name,
                    Description = vm.Description
                };

                await _typePropertyService.CreateAsync(request);
            }

            if (vm.Table == Tables.TypeSale.ToString()) 
            {
                SaveTypeSaleViewModel request = new SaveTypeSaleViewModel
                {
                    Name = vm.Name,
                    Description = vm.Description
                };

                await _typeSaleService.CreateAsync(request);
            }

            await _requestService.DeleteAsync(Id);
            return RedirectToRoute(new { controller = "Admin", action = "Requests" });

        }

        public  IActionResult DeleteRequest(int Id)
        {
            return View(Id);
        }
        public async Task<IActionResult> DeleteRequestPost(int Id)
        {
            await _requestService.DeleteAsync(Id);
            return RedirectToRoute(new { controller = "Admin", action = "Requests" });
        }


    }
}
