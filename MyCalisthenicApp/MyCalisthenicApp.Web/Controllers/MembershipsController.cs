namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;

    public class MembershipsController : BaseController
    {
        private readonly IMembershipsService membershipsService;

        public MembershipsController(IMembershipsService membershipsService)
        {
            this.membershipsService = membershipsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
