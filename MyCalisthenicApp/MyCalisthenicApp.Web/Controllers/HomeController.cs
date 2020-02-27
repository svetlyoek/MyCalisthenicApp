namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Web.Models;
    using MyCalisthenicApp.Web.ViewModels.Home;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRequestsService userRequestsService;

        public HomeController(ILogger<HomeController> logger,IUserRequestsService userRequestsService)
        {
            this._logger = logger;
            this.userRequestsService = userRequestsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Contact(ContactRequestInputViewModel inputModel)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.userRequestsService.Create(inputModel.FullName, inputModel.Email, inputModel.PhoneNumber, inputModel.Content);

            return this.RedirectToAction("/Home/Index");
        }

        public IActionResult Trainer()
        {
            return View();
        }

        public IActionResult Program()
        {
            return View();
        }

        public IActionResult Membership()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return this.View();
        }

        public IActionResult ShoppingBag()
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        public IActionResult Error404(int statusCode)
        {
            if(statusCode==404)
            {
                return View();
            }

            return this.Redirect("Error");
            
        }

        public IActionResult ComingSoon()
        {
            return View();
        }
    }
}
