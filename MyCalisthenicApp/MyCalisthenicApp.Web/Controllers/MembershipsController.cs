namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    public class MembershipsController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly IMembershipsService membershipsService;

        public MembershipsController(IOrdersService ordersService, IMembershipsService membershipsService)
        {
            this.ordersService = ordersService;
            this.membershipsService = membershipsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public async Task<IActionResult> Buy(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("Error404");
            }

            var membershipPrice = await this.membershipsService.GetMembershipPriceByIdAsync(id);

            await this.ordersService.CreateMembershipToOrder(membershipPrice);

            return this.LocalRedirect("/ShoppingCarts/Index");

        }
    }
}
