namespace MyCalisthenicApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Home;

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
        public IActionResult Index(ContactRequestInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            this.userRequestsService.Create(inputModel.FullName, inputModel.Email, inputModel.PhoneNumber, inputModel.Content);

            return this.RedirectToAction("/Home/Index");
        }
    }
}
