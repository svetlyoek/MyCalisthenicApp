namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Home;
    using System.Threading.Tasks;

    public class ContactsController : Controller
    {
        private readonly IUserRequestsService userRequestsService;

        public ContactsController(IUserRequestsService userRequestsService)
        {
            this.userRequestsService = userRequestsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactRequestInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.userRequestsService.CreateAsync(inputModel.FullName, inputModel.Email, inputModel.PhoneNumber, inputModel.Content);

            return this.RedirectToAction("/Home/Index");
        }
    }
}
