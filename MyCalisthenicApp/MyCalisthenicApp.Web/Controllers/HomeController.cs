namespace MyCalisthenicApp.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Services.MessageSender;
    using MyCalisthenicApp.ViewModels;
    using MyCalisthenicApp.ViewModels.Home;
    using MyCalisthenicApp.ViewModels.Posts;
    using MyCalisthenicApp.ViewModels.Products;
    using MyCalisthenicApp.ViewModels.Subscribes;
    using MyCalisthenicApp.Web.Common;

    public class HomeController : BaseController
    {
        private readonly IEmailSender emailSender;
        private readonly ISearchesService searchesService;
        private readonly IUsersService usersService;
        private readonly IPostsService postsService;

        public HomeController(
            IEmailSender emailSender,
            ISearchesService searchesService,
            IUsersService usersService,
            IPostsService postsService)
        {
            this.emailSender = emailSender;
            this.searchesService = searchesService;
            this.usersService = usersService;
            this.postsService = postsService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.usersService.CheckUserMembershipAsync();

            if (result)
            {
                this.TempData["MembershipMessage"] = GlobalConstants.ExpiredMembership;
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
        public async Task<IActionResult> Search(SearchViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Error404");
            }

            var programs = await this.searchesService.GetProgramsBySearchTextAsync(inputModel);

            if (programs != null)
            {
                return this.View("~/Views/Programs/Index.cshtml", programs);
            }

            var products = await this.searchesService.GetProductsBySearchTextAsync(inputModel);

            if (products != null)
            {
                var productsPageViewModel = new ProductsPageViewModel
                {
                    ProductPerPage = ServicesConstants.PostsCountPerPage,
                    Products = products,
                };

                return this.View("~/Views/Products/Index.cshtml", productsPageViewModel);
            }

            var posts = await this.postsService.GetPostsBySearchAsync(inputModel);

            if (posts != null)
            {
                var postPageViewModel = new PostPageViewModel
                {
                    PostsPerPage = ServicesConstants.PostsCountPerPage,
                    Posts = posts,
                };

                return this.View("~/Views/Posts/Index.cshtml", postPageViewModel);
            }

            return this.View("Error404");
        }

        public IActionResult ComingSoon()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [Route("/")]
        public async Task<IActionResult> Subscribe(SubscribeInputViewModel inputModel)
        {
            var userId = this.usersService.GetLoggedUserId();

            var user = await this.usersService.GetLoggedUserByIdAsync(userId);

            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            if (user.HasSubscribe)
            {
                this.TempData["SubscribeMessage"] = GlobalConstants.UserSubscribeDenied;

                return this.RedirectToAction("Index");
            }
            else
            {
                this.TempData["SubscribeMessage"] = GlobalConstants.UserSubscribeSuccess;

                await this.usersService.UserSubscribeAsync(user);

                await this.SendEmail(inputModel);

                return this.RedirectToAction("Index");
            }
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
