using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Interfaces.Service;
using RealEstateApp.Core.Application.ViewModels.TypeSale;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Controllers
{

    [Authorize(Roles = "Admin, SuperAdmin")]
    public class TypeSaleController : Controller
    {
        public readonly ITypeSaleService _typeSaleServices;

        public TypeSaleController(ITypeSaleService typeSaleServices)
        {
            _typeSaleServices = typeSaleServices;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _typeSaleServices.GetAllViewModelWithInclude());
        }

        public IActionResult Create()
        {
            return View("SaveTypeSale", new SaveTypeSaleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveTypeSaleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTypeSale", vm);
            }

            await _typeSaleServices.CreateAsync(vm);
            return RedirectToRoute(new { controller = "TypeSale", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveTypeSale", await _typeSaleServices.GetByIdSaveViewModelAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SaveTypeSaleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTypeSale", vm);
            }

            await _typeSaleServices.UpdateAsync(vm, vm.Id);
            return RedirectToRoute(new { controller = "TypeSale", action = "Index" });
        }



        public async Task<IActionResult> Delete(int id)
        {
            return View(await _typeSaleServices.GetByIdSaveViewModelAsync(id));
        }

        public async Task<IActionResult> DeletePost(int id)
        {
            await _typeSaleServices.DeleteAsync(id);
            return RedirectToRoute(new { controller = "TypeSale", action = "Index" });
        }

    }


}
