namespace MyCalisthenicApp.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MyCalisthenicApp.Services.MessageSender;
    using MyCalisthenicApp.ViewModels;
    using MyCalisthenicApp.ViewModels.Subscribes;
    using MyCalisthenicApp.Web.Common;

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly IEmailSender emailSender;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
            this.logger = logger;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet("~/Views/Home/Privacy.cshtml")]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult Error404(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.View();
            }

            return this.Redirect("Error");
        }

        [HttpPost]
        [Authorize]
        [Route("/Home/Subscribe")]
        public async Task<IActionResult> Subscribe(SubscribeInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Error404");
            }

            await this.SendEmail(inputModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult ComingSoon()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ComingSoon(SubscribeInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.SendEmail(inputModel);

            return this.RedirectToAction("Index");
        }

        private async Task SendEmail(SubscribeInputViewModel inputModel)
        {
            await this.emailSender.SendEmailAsync(
            GlobalConstants.ApplicationSendEmail,
            GlobalConstants.AdministratorRoleName,
            inputModel.Email,
            GlobalConstants.SubscribeEmailSubject,
            GlobalConstants.SubscribeEmailContent);

            await this.emailSender.SendEmailAsync(
                GlobalConstants.ApplicationSendEmail,
                GlobalConstants.AdministratorRoleName,
                GlobalConstants.AdministratorReceiveEmail,
                GlobalConstants.AdministratorSubscribeEmailSubject,
                string.Format(GlobalConstants.AdministratorSubscribeEmailContent, inputModel.Email));
        }
    }
}
