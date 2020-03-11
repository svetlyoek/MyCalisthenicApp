namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        public IActionResult Details()
        {
            return this.View();
        }
    }
}
