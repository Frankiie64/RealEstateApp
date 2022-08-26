using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class TypePropertyController : Controller
    {
        public readonly ITypePropertyService _typePropertyServices;


        public TypePropertyController(ITypePropertyService typePropertyServices)
        {
            _typePropertyServices = typePropertyServices;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _typePropertyServices.GetAllViewModelWithInclude());
        }

        public IActionResult Create()
        {
            return View("SaveTypeProperty", new SaveTypePropertyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveTypePropertyViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTypeProperty", vm);
            }

            await _typePropertyServices.CreateAsync(vm);
            return RedirectToRoute(new { controller = "TypeProperty", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveTypeProperty", await _typePropertyServices.GetByIdSaveViewModelAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SaveTypePropertyViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTypeProperty", vm);
            }

            await _typePropertyServices.UpdateAsync(vm, vm.Id);
            return RedirectToRoute(new { controller = "TypeProperty", action = "Index" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _typePropertyServices.GetByIdSaveViewModelAsync(id));
        }

        public async Task<IActionResult> DeletePost(int id)
        {
            await _typePropertyServices.DeleteAsync(id);
            return RedirectToRoute(new { controller = "TypeProperty", action = "Index" });
        }
    }
}
