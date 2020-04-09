namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Addresses;

    public class AddressesController : AdministratorController
    {
        private readonly IAddressesService addressesService;

        public AddressesController(IAddressesService addressesService)
        {
            this.addressesService = addressesService;
        }

        public async Task<IActionResult> Edit(string id)
        {
            var address = await this.addressesService.GetAddressByIdAsync(id);

            return this.View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddressAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.addressesService.EditAddressAsync(inputModel);

            return this.RedirectToAction("Addresses", "Users", new { id = inputModel.UserId });
        }
    }
}
