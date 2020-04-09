namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Memberships;

    public class MembershipsController : AdministratorController
    {
        private readonly IMembershipsService membershipsService;

        public MembershipsController(IMembershipsService membershipsService)
        {
            this.membershipsService = membershipsService;
        }

        public async Task<IActionResult> All()
        {
            var memberships = await this.membershipsService.GetAllMembershipsAsync();

            return this.View(memberships);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var membership = await this.membershipsService.GetMembershipByIdAsync(id);

            return this.View(membership);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MembershipAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.membershipsService.EditMembershipAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MembershipAdminCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.membershipsService.CreateMembershipAsync(inputModel);

            return this.RedirectToAction("All");
        }
    }
}
