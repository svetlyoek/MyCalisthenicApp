namespace MyCalisthenicApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Products;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly ICommentsService commentsService;
        private readonly IImagesService imagesService;

        public ProductsController(IProductsService productsService, ICommentsService commentsService, IImagesService imagesService)
        {
            this.productsService = productsService;
            this.commentsService = commentsService;
            this.imagesService = imagesService;
        }

        public async Task<IActionResult> Index(int page)
        {
            var products = await this.productsService.GetAllProductsAsync();

            var productsViewModel = new ProductsPageViewModel
            {
                ProductPerPage = ServicesConstants.ProductsCountPerPage,
                CurrentPage = page,
                Products = products,
            };

            return this.View(productsViewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Error404");
            }

            var product = await this.productsService.GetProductsByIdAsync(id);

            var comments = await this.commentsService.GetCommentsByProductIdAsync(product.Id);
            product.Comments = comments;

            var images = await this.imagesService.GetImagesByProductIdAsync(id);
            product.Images = images;

            return this.View(product);
        }

        public async Task<IActionResult> Filter(string name)
        {
            var products = await this.productsService.GetProductsByCategoryAsync(name);

            var productsViewModel = new ProductsPageViewModel
            {
                ProductPerPage = ServicesConstants.ProductsCountPerPage,
                CurrentPage = ServicesConstants.ProductsDefaultPage,
                Products = products,
            };

            return this.View("Index", productsViewModel);
        }

        public async Task<IActionResult> Sort(string sort)
        {
            var products = await this.productsService.GetProductsAndSortAsync(sort);

            var productsViewModel = new ProductsPageViewModel
            {
                ProductPerPage = ServicesConstants.ProductsCountPerPage,
                CurrentPage = ServicesConstants.ProductsDefaultPage,
                Products = products,
            };

            return this.View("Index", productsViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Rate(string id)
        {
            await this.productsService.AddRatingAsync(id);

            return this.RedirectToAction(nameof(this.Details), new { id = id });
        }

    }
}
