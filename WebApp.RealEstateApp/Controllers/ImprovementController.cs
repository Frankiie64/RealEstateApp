using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.ViewModels.Improvement;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class ImprovementController : Controller
    {
        public readonly IImprovementService _improvementServices;


        public ImprovementController(IImprovementService improvementServices)
        {
            _improvementServices = improvementServices;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _improvementServices.GetAllViewModelAsync());
        }

        public IActionResult Create()
        {
            return View("SaveImprovement", new SaveImprovementViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveImprovementViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveImprovement", vm);
            }

            await _improvementServices.CreateAsync(vm);
            return RedirectToRoute(new { controller = "Improvement", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveImprovement", await _improvementServices.GetByIdSaveViewModelAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SaveImprovementViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveImprovement", vm);
            }

            await _improvementServices.UpdateAsync(vm, vm.Id);
            return RedirectToRoute(new { controller = "Improvement", action = "Index" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _improvementServices.GetByIdSaveViewModelAsync(id));
        }

        public async Task<IActionResult> DeletePost(int id)
        {
            await _improvementServices.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Improvement", action = "Index" });
        }
    }
}
