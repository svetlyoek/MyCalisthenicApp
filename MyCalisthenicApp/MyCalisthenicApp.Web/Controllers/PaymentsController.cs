namespace MyCalisthenicApp.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Models.ShopEntities.Enums;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Services.MessageSender;
    using MyCalisthenicApp.Web.Common;

    [Authorize]
    public class PaymentsController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly IEmailSender emailSender;
        private readonly IUsersService usersService;

        public PaymentsController(
            IOrdersService ordersService,
            IEmailSender emailSender,
            IUsersService usersService)
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
            var userId = this.usersService.GetLoggedUserId();

            var user = await this.usersService.GetLoggedUserByIdAsync(userId);

            var result = await this.ordersService.SendOrderAsync(id);

            var orderNumber = user.Orders
                .Where(o => o.UserId == userId)
                .Select(o => o.Id)
                .FirstOrDefault();

            var userEmail = user.Email;

            if (result)
            {
                var order = user.Orders.Where(o => o.UserId == userId)
             .Where(o => o.IsDeleted == false)
             .Where(o => o.Status == OrderStatus.Sent)
             .FirstOrDefault();

                this.TempData["InfoMessage"] = "Successfully sent order.";

                await this.emailSender.SendEmailAsync(
              GlobalConstants.ApplicationSendEmail,
              GlobalConstants.AdministratorRoleName,
              userEmail,
              string.Format(GlobalConstants.SuccessfullSendOrderSubject, orderNumber),
              string.Format(
              GlobalConstants.SuccessfullSendContent,
              orderNumber,
              order.MembershipPrice != null ? order.TotalPrice + order.DeliveryPrice + order.MembershipPrice : order.TotalPrice + order.DeliveryPrice,
              order.Status.ToString(),
              order.PaymentStatus.ToString(),
              order.DisptachDate.Value.Date.ToShortDateString()));
            }
            else
            {
                this.TempData["InfoMessage"] = "Order was denied! We will keep in touch very soon...";
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
