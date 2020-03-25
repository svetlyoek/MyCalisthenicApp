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
        private readonly IUsersService usersService;

        public MembershipsController(IOrdersService ordersService, IMembershipsService membershipsService, IUsersService usersService)
        {
            this.ordersService = ordersService;
            this.membershipsService = membershipsService;
            this.usersService = usersService;
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

            var userId = this.usersService.GetLoggedUserId();

            var user = await this.usersService.GetLoggedUserById(userId);

            if (user.HasMembership)
            {
                return this.LocalRedirect("/Memberships/Index");
            }

            return this.LocalRedirect("/Payments/Index");
        }
    }
}
