namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Services.MessageSender;
    using MyCalisthenicApp.ViewModels.Contacts;
    using MyCalisthenicApp.Web.Common;

    public class ContactsController : Controller
    {
        private readonly IUserRequestsService userRequestsService;
        private readonly IEmailSender emailSender;

        public ContactsController(IUserRequestsService userRequestsService, IEmailSender emailSender)
        {
            this.userRequestsService = userRequestsService;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.userRequestsService.CreateAsync(inputModel.FullName, inputModel.Email, inputModel.Content);

            await this.emailSender.SendEmailAsync(
               inputModel.Email,
               inputModel.FullName,
               GlobalConstants.AdministratorEmail,
               inputModel.Title,
               inputModel.Content);

            return this.RedirectToAction("Successfull");
        }

        public IActionResult Successfull()
        {
            return this.View();
        }
    }
}
