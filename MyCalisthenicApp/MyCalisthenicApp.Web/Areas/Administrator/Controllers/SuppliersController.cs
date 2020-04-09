namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Suppliers;

    public class SuppliersController : AdministratorController
    {
        private readonly ISuppliersService suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            this.suppliersService = suppliersService;
        }

        public async Task<IActionResult> All()
        {
            var suppliers = await this.suppliersService.GetAllSuppliersForAdminAsync();

            return this.View(suppliers);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var supplier = await this.suppliersService.GetSupplierByIdAsync(id);

            return this.View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupplierAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.suppliersService.EditSupplierAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.suppliersService.CreateSupplierAsync(inputModel);

            return this.RedirectToAction("All");
        }
    }
}
