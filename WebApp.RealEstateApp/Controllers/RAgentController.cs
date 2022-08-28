using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.Interfaces.Services;
using RealEstateApp.Core.Application.ViewModels.PhotoProperties;
using RealEstateApp.Core.Application.ViewModels.Property;
using RealEstateApp.Core.Application.ViewModels.Request;
using RealEstateApp.Core.Application.ViewModels.TypeImproments;
using RealEstateApp.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.RealEstateApp.Models;

namespace WebApp.RealEstateApp.Controllers
{
    [Authorize(Roles = "Agent")]
    public class RAgentController : Controller
    {
        private readonly IPropertyService serviceProperty;
        private readonly ITypePropertyService serviceTypeProperty;
        private readonly ITypeSaleService serviceTypeSale;
        private readonly ITypeImpromentsServices servicesTypeImproments;
        private readonly IImprovementService serviceImprovement;
        private  readonly IPhotosOfPropertyService servicesPhotos;
        private readonly IUserService userService;
        private readonly IRequestService requestService;
        private readonly IHttpContextAccessor context;

        AuthenticationResponse user;

        public RAgentController(IHttpContextAccessor context, IPropertyService serviceProperty, IPhotosOfPropertyService servicesPhotos, ITypePropertyService serviceTypeProperty,
            ITypeSaleService serviceTypeSale, IImprovementService serviceImprovement, ITypeImpromentsServices servicesTypeImproments, IUserService userService,
            IRequestService requestService)
        {        
            this.context = context;
            this.serviceProperty = serviceProperty;
            this.servicesPhotos = servicesPhotos;
            this.servicesTypeImproments = servicesTypeImproments;
            this.serviceTypeProperty = serviceTypeProperty;
            this.serviceTypeSale = serviceTypeSale;
            this.serviceImprovement = serviceImprovement;
            this.userService = userService;
            this.requestService = requestService;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        public async Task<IActionResult> Index()
        {
            var Properties = await serviceProperty.GetAllViewModelWithIncludeAsync();
            ViewBag.Properties = Properties.Where(x => x.AgentId == user.Id).ToList();
            return View();
        }
        public async Task<IActionResult> Properties()
        {
            var Properties = await serviceProperty.GetAllViewModelWithIncludeAsync();
            ViewBag.Properties = Properties.Where(x => x.AgentId == user.Id).ToList();

            return View();
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.typePrperties = await serviceTypeProperty.GetAllViewModelAsync();
            ViewBag.typeSale = await serviceTypeSale.GetAllViewModelAsync();
            ViewBag.improvements = await serviceImprovement.GetAllViewModelAsync();

            return View(new SavePropertyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(SavePropertyViewModel vm)
        {
            vm.HasError = false;
            vm.AgentId = user.Id;
            vm.Creadted = DateTime.Now;
            vm.CreatedBy = "user";

            ViewBag.typePrperties = await serviceTypeProperty.GetAllViewModelAsync();
            ViewBag.typeSale = await serviceTypeSale.GetAllViewModelAsync();
            ViewBag.improvements = await serviceImprovement.GetAllViewModelAsync();

            if (!ModelState.IsValid)
            {
                return View("Create",vm);
            }

            if (vm.IdImproments.Count == 0)
            {
                vm.HasError = true;
                vm.Error = "Debe seleccionar alguna de las mejoras que se encuentran disponibles.";
                return View("Create", vm);

            }
            if (vm.File.Count <= 0 || vm.File.Count > 4)
            {
                vm.HasError = true;
                vm.Error = "Debes de seleccionar de 1 a 4 imagenes para la visualizacion de la propiedad.";
                return View("Create", vm);

            }

            var response = await serviceProperty.CreateAsync(vm);

            if (response == null ||response.Id == 0)
            {
                vm.HasError = true;
                vm.Error = "Ha ocurrido un error cuando se estaba creando la propiedad.";
                return View("Create", vm);
            }

            foreach (var item in vm.File)
            {
                vm.UrlPhotos.Add(Photo.Upload(item, "Properties", response.Id.ToString()));
            }
            foreach (var url in vm.UrlPhotos)
            {
                SavePhotosPropertyViewModel photos = new SavePhotosPropertyViewModel
                {
                    IdProperty = response.Id,
                    ImagUrl = url
                 };           
                 await servicesPhotos.CreateAsync(photos);
            }
            foreach (var item in vm.IdImproments)
            {
                SaveTypeImpromentsViewModel improvements = new SaveTypeImpromentsViewModel
                {
                    IdImproment = item,
                    IdProperty = response.Id,
                };
                await servicesTypeImproments.CreateAsync(improvements);
            }
          
            return RedirectToRoute(new { controller = "RAgent", action = "Properties" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.typePrperties = await serviceTypeProperty.GetAllViewModelAsync();
            ViewBag.typeSale = await serviceTypeSale.GetAllViewModelAsync();
            ViewBag.improvements = await serviceImprovement.GetAllViewModelAsync();

            var typeImp = await servicesTypeImproments.GetAllViewModelAsync();
            var vm = await serviceProperty.GetByIdSaveViewModelAsync(id);

            vm.IdImproments = typeImp.Where(x => x.IdProperty == vm.Id).Select(x=>x.IdImproment).ToList();
            vm.HasError = true;
            vm.Error = "Asegurate de guardar los cambios antes de  ir al apartado de editar fotos.";
            return View("Create",vm);
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(SavePropertyViewModel vm)
        {
            var prop = await serviceProperty.GetByIdSaveViewModelAsync(vm.Id);

            vm.Creadted = prop.Creadted;
            vm.CreatedBy = prop.CreatedBy;
            vm.HasError = false;
            vm.AgentId = user.Id;
        
            var response = await serviceProperty.UpdateAsync(vm,vm.Id);

            if (!response)
            {
                ViewBag.typePrperties = await serviceTypeProperty.GetAllViewModelAsync();
                ViewBag.typeSale = await serviceTypeSale.GetAllViewModelAsync();
                ViewBag.improvements = await serviceImprovement.GetAllViewModelAsync();

                vm.HasError = true;
                vm.Error = "Ha ocurrido un error cuando se estaba actualizando la propiedad.";
                return View("Create", vm);
            }

            var improvoments = await servicesTypeImproments.GetAllViewModelAsync();
            improvoments = improvoments.Where(x => x.IdProperty == vm.Id).ToList();

            improvoments.ForEach(x => servicesTypeImproments.DeleteAsync(x.Id).Wait());

            foreach (var item in vm.IdImproments)
            {
                SaveTypeImpromentsViewModel improvements = new SaveTypeImpromentsViewModel
                {
                    IdImproment = item,
                    IdProperty = vm.Id
                };
                await servicesTypeImproments.CreateAsync(improvements);
            }       
          
            return RedirectToRoute(new { controller = "RAgent", action = "Properties" });
        }
      
        public async Task<IActionResult> Delete(int id)
        {
            var vm = await serviceProperty.GetByIdSaveViewModelAsync(id);
            return View(vm);
        }
       
        [HttpPost]
        public async Task<IActionResult> DeletePost(SavePropertyViewModel vm)
        {
            Photo.Delete("Properties", vm.Id.ToString());

            var photos = await servicesPhotos.GetAllViewModelAsync();
            photos = photos.Where(x => x.IdProperty == vm.Id).ToList();

            photos.ForEach(x => servicesPhotos.DeleteAsync(x.Id).Wait());

            var improvoments = await servicesTypeImproments.GetAllViewModelAsync();
            improvoments = improvoments.Where(x=> x.IdProperty == vm.Id).ToList();

            improvoments.ForEach(x => servicesTypeImproments.DeleteAsync(x.Id).Wait());

            await serviceProperty.DeleteAsync(vm.Id);

            return RedirectToRoute(new { controller = "RAgent", action = "Index" });
        }
        public async Task<IActionResult> IndexPhoto(int id)
        {
            var photos = await servicesPhotos.GetAllViewModelAsync();
            photos = photos.Where(x => x.IdProperty == id).ToList();

            ViewBag.Photos = photos.ToList();

            return View();
        }
        public IActionResult CreatePhoto(int idProperty)
        {
            return View(new RequestPhoto { idProperty = idProperty });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhoto(RequestPhoto request)
        {
            request.HasError = false;

            if (request.File == null)
            {
                request.HasError = true;
                request.Error = "Debe seleccioar alguna foto";
                return View(request);
            }

            request.ImgUrl= Photo.Upload(request.File, "Properties", request.idProperty.ToString());

            SavePhotosPropertyViewModel vm = new SavePhotosPropertyViewModel
            {
                IdProperty = request.idProperty,
                ImagUrl = request.ImgUrl
            };

            var response = await servicesPhotos.CreateAsync(vm);

            if (response == null)
            {
                request.HasError = true;
                request.Error =  "Ha ocurrido algun error cuando se intento guardar una foto.";
                return View(request);
            }

            return RedirectToRoute(new { controller = "RAgent", action = "IndexPhoto",id = request.idProperty });
        }
        public IActionResult EditPhoto(RequestPhoto request)
        {
            return View("CreatePhoto",new RequestPhoto {Id = request.Id, idProperty = request.idProperty });
        }
        [HttpPost]
        public async Task<IActionResult> EditPhotoPost(RequestPhoto request)
        {
            request.HasError = false;

            if (request.File == null)
            {
                request.HasError = true;
                request.Error = "Debe seleccioar alguna foto";
                return View("CreatePhoto",request);
            }

            var oldImg = await servicesPhotos.GetByIdSaveViewModelAsync(request.Id);
            request.ImgUrl = Photo.Upload(request.File, "Properties", request.idProperty.ToString(),true,oldImg.ImagUrl);

            SavePhotosPropertyViewModel vm = new SavePhotosPropertyViewModel
            {
                Id = request.Id,
                IdProperty = request.idProperty,
                ImagUrl = request.ImgUrl
            };

            bool response = await servicesPhotos.UpdateAsync(vm,request.Id);

            if (!response)
            {
                request.HasError = true;
                request.Error = "Ha ocurrido algun error cuando se intento subir la foto.";
                return View("CreatePhoto",request);
            }           

            return RedirectToRoute(new { controller = "RAgent", action = "IndexPhoto", id = request.idProperty });
        }
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photos = await servicesPhotos.GetAllViewModelAsync();
            var photo = photos.Where(x => x.Id == id).SingleOrDefault();

            List<string> PartsOfPhoto = photo.ImagUrl.Split("/").ToList();

            
            Photo.DeleteOnePhoto("Properties", photo.IdProperty.ToString(), PartsOfPhoto.Last());

            await servicesPhotos.DeleteAsync(id);

            photos = await servicesPhotos.GetAllViewModelAsync();
            photos = photos.Where(x => x.IdProperty == photo.IdProperty).ToList();
            ViewBag.Photos = photos.ToList();

            return View("IndexPhoto");
        }
        public async Task<IActionResult> Profile()
        {
            var OldUser = await userService.GetUserByIdAsync(user.Id);

            requestAgent request = new requestAgent
            {
                Id = OldUser.Id,
                Firstname = OldUser.Firstname,
                Lastname = OldUser.Lastname,
                PhoneNumber = OldUser.PhoneNumber,
                PhotoProfileUrl = OldUser.PhotoProfileUrl
            };

            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(requestAgent request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            if (request.file != null)
            {
                request.PhotoProfileUrl = Photo.Upload(request.file, "User", request.Id, true, request.PhotoProfileUrl);
            }


            UserVM userVm = await userService.GetUserByIdAsync(request.Id);

            SaveUserVM vm = new SaveUserVM
            {
                Id = request.Id,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                PhoneNumber = request.PhoneNumber,
                PhotoProfileUrl = request.PhotoProfileUrl,
                Username = userVm.Username,
                Email = userVm.Email
            };

            var value = await userService.UpdateAsync(vm, vm.Id);

            if (value.HasError)
            {
                request.HasError = true;
                request.Error = "Ha ocurrido algun problema con la actualización.";
                return View("CreatePhoto", request);
            }

            var json = user;

            json.PhotoProfileUrl = vm.PhotoProfileUrl;      

            HttpContext.Session.Set<AuthenticationResponse>("user", json);

            return RedirectToRoute(new { controller = "RAgent", action = "Profile" });
        }

        public IActionResult CreateRequest()
        {            
            return View(new SaveRequestViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateRequest(SaveRequestViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var response = await requestService.CreateAsync(vm);

            if (response == null || response.Id == 0)
            {
                vm.HasError = true;
                vm.Error = "Ha ocurrido algun problema cuando se intento crear la solicitud.";
                return View(vm);
            }

            return RedirectToRoute(new { controller = "RAgent", action = "Index" });
        }
        private string EditPhoto(IFormFile file, int idProperty, string imagePath)
        {
           
            string basePath = $"/Img/Properties/{idProperty}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");



                    Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string[] oldImagePart = imagePath.Split("/");
            string oldImagePath = oldImagePart[^1];
            string completeImageOldPath = Path.Combine(path, oldImagePath);

            if (System.IO.File.Exists(completeImageOldPath))
            {
                System.IO.File.Delete(completeImageOldPath);
            }

            return $"{basePath}/{fileName}";
        }
    }
}
