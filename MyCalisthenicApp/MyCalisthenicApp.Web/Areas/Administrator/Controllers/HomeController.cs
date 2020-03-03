namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdministratorController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
