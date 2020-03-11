namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TrainersController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
