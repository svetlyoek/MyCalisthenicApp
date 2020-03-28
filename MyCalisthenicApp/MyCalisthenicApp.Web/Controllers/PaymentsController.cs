namespace MyCalisthenicApp.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Services.MessageSender;
    using MyCalisthenicApp.Web.Common;

    [Authorize]
    public class PaymentsController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly IEmailSender emailSender;
        private readonly IUsersService usersService;

        public PaymentsController(IOrdersService ordersService, IEmailSender emailSender, IUsersService usersService)
        {
            this.ordersService = ordersService;
            this.emailSender = emailSender;
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var order = await this.ordersService.GetOrderToSendAsync();

            return this.View(order);
        }

        public async Task<IActionResult> OnDelivery(string id)
        {
            var result = await this.ordersService.SendOrder(id);

            var userId = this.usersService.GetLoggedUserId();

            var user = await this.usersService.GetLoggedUserById(userId);

            var userNumber = user.Orders
                .Where(o => o.UserId == userId)
                .Select(o => o.Id)
                .FirstOrDefault();

            var userEmail = user.Email;

            if (result)
            {
                this.TempData["InfoMessage"] = "Successfully sent order.";
            }
            else
            {
                this.TempData["InfoMessage"] = "Order was denied! We will keep in touch very soon...";
            }

            await this.emailSender.SendEmailAsync(
                GlobalConstants.ApplicationSendEmail,
                GlobalConstants.AdministratorRoleName,
                userEmail,
                string.Format(GlobalConstants.SuccessfullSendOrderSubject, userNumber),
                null);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
