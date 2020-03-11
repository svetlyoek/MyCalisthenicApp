namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ShopsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
