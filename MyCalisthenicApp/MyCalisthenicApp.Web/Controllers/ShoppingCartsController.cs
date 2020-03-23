namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ShoppingCartsController : BaseController
    {
        public ShoppingCartsController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
