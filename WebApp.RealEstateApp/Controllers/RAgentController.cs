using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.helper;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.Interfaces.Service.Service_App;
using RealEstateApp.Core.Application.ViewModels.PhotoProperties;
using RealEstateApp.Core.Application.ViewModels.Property;
using RealEstateApp.Core.Application.ViewModels.TypeImproments;
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
        private IPhotosOfPropertyService servicesPhotos;
        private readonly IHttpContextAccessor context;
        AuthenticationResponse user;

        public RAgentController(IHttpContextAccessor context, IPropertyService serviceProperty, IPhotosOfPropertyService servicesPhotos, ITypePropertyService serviceTypeProperty,
            ITypeSaleService serviceTypeSale, IImprovementService serviceImprovement, ITypeImpromentsServices servicesTypeImproments)
        {        
            this.context = context;
            this.serviceProperty = serviceProperty;
            this.servicesPhotos = servicesPhotos;
            this.servicesTypeImproments = servicesTypeImproments;
            this.serviceTypeProperty = serviceTypeProperty;
            this.serviceTypeSale = serviceTypeSale;
            this.serviceImprovement = serviceImprovement;
            user = context.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        public async Task<IActionResult> Index()
        {
            var Properties = await serviceProperty.GetAllViewModelWithIncludeAsync();
            Properties = Properties.OrderBy(x => x.Creadted).ToList();
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
            return View(new RequestPhoto { IdProperty = idProperty });
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

            request.ImgUrl= Photo.Upload(request.File, "Properties", request.IdProperty.ToString());

            SavePhotosPropertyViewModel vm = new SavePhotosPropertyViewModel
            {
                IdProperty = request.IdProperty,
                ImagUrl = request.ImgUrl
            };

            var response = await servicesPhotos.CreateAsync(vm);

            if (response == null)
            {
                request.HasError = true;
                request.Error =  "Ha ocurrido algun error cuando se intento guardar una foto.";
                return View(request);
            }

            return RedirectToRoute(new { controller = "RAgent", action = "IndexPhoto",id = request.IdProperty });
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
        public IActionResult Profile()
        {
            return View();
        }

    }
}
