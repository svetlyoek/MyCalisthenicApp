namespace MyCalisthenicApp.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Services.MessageSender;
    using MyCalisthenicApp.ViewModels;
    using MyCalisthenicApp.ViewModels.Home;
    using MyCalisthenicApp.ViewModels.Posts;
    using MyCalisthenicApp.ViewModels.Products;
    using MyCalisthenicApp.ViewModels.Programs;
    using MyCalisthenicApp.ViewModels.Subscribes;
    using MyCalisthenicApp.Web.Common;

    public class HomeController : BaseController
    {
        private readonly IEmailSender emailSender;
        private readonly ISearchesService searchesService;
        private readonly IUsersService usersService;

        public HomeController(IEmailSender emailSender, ISearchesService searchesService, IUsersService usersService)
        {
            this.emailSender = emailSender;
            this.searchesService = searchesService;
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.usersService.CheckUserMembershipAsync();

            if (result)
            {
                this.TempData["MembershipMessage"] = "Your membership expired!";
            }

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

        [HttpPost]
        public async Task<IActionResult> Search(NavbarSearchViewModel inputModel)
        {
            var elements = await this.searchesService.GetElementsBySearchTextAsync(inputModel);

            if (!this.ModelState.IsValid || elements == null)
            {
                return this.View("Error404");
            }

            foreach (var element in elements)
            {
                if (element is PostDetailsViewModel)
                {
                    return this.View("~/Views/Posts/Index.cshtml", elements);
                }

                if (element is ProductsViewModel)
                {
                    return this.View("~/Views/Products/Index.cshtml", elements);
                }

                if (element is ProgramViewModel)
                {
                    return this.View("~/Views/Programs/Index.cshtml", elements);
                }
            }

            return this.View("Index");
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
