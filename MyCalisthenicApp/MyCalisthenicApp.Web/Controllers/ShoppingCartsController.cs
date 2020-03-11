namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
