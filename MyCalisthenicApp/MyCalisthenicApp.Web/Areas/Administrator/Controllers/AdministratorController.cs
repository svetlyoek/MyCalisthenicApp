namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
       
    }
}
