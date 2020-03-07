namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
