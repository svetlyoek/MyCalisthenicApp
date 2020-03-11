namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingBagsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
