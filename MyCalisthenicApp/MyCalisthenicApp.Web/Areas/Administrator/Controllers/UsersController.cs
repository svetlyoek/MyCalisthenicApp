namespace MyCalisthenicApp.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Users;

    public class UsersController : AdministratorController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> All()
        {
            var allUsers = await this.usersService.GetAllUsersAsync();

            return this.View(allUsers);
        }

        public async Task<IActionResult> Banned()
        {
            var bannedUsers = await this.usersService.GetBannedUsersAsync();

            return this.View(bannedUsers);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await this.usersService.GetUserToEditAsync(id);

            return this.View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserAdminEditViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.usersService.EditUserAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> BlockUnblock(string id)
        {
            var user = await this.usersService.BlockUnblockUserByIdAsync(id);

            if (user.IsDeleted)
            {
                return this.RedirectToAction("All");
            }
            else
            {
                return this.RedirectToAction("Banned");
            }
        }

        public async Task<IActionResult> Addresses(string id)
        {
            var addresses = await this.usersService.GetAllAddressesByUserIdAsync(id);

            return this.View(addresses);
        }

        public async Task<IActionResult> Orders(string id)
        {
            var orders = await this.usersService.GetAllOrdersByUserIdAsync(id);

            return this.View(orders);
        }

        public async Task<IActionResult> AllOrders()
        {
            var orders = await this.usersService.GetAllOrdersAsync();

            return this.View(orders);
        }

        public async Task<IActionResult> Comments(string id)
        {
            var comments = await this.usersService.GetAllCommentsByUserIdAsync(id);

            return this.View(comments);
        }

        public async Task<IActionResult> Requests()
        {
            var requests = await this.usersService.GetAllRequestsAsync();

            return this.View(requests);
        }
    }
}
