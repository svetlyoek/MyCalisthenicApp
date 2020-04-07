namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models.ShopEntities;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Images;

    public class ImagesService : IImagesService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IPostsService postsService;
        private readonly IExercisesService exercisesService;
        private readonly IProductsService productsService;
        private readonly IProgramsService programsService;

        public ImagesService(
            MyCalisthenicAppDbContext dbCotext,
            IMapper mapper,
            IPostsService postsService,
            IExercisesService exercisesService,
            IProductsService productsService,
            IProgramsService programsService)
        {
            this.dbContext = dbCotext;
            this.mapper = mapper;
            this.postsService = postsService;
            this.exercisesService = exercisesService;
            this.productsService = productsService;
            this.programsService = programsService;
        }

        public async Task<ImageAdminEditViewModel> GetImageByIdAsync(string id)
        {
            var image = await this.dbContext.Images
                 .FirstOrDefaultAsync(i => i.Id == id);

            if (image == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidImageId, id));
            }

            var posts = await this.postsService.GetAllPostsForAdminAsync();

            var products = await this.productsService.GetProductsForAdminAsync();

            var exercises = await this.exercisesService.GetAllExercisesForAdminAsync();

            var programs = await this.programsService.GetAllProgramsForAdminAsync();

            var imageViewModel = this.mapper.Map<ImageAdminEditViewModel>(image);

            imageViewModel.Posts = posts
               .Select(c => new List<string> { c.Id, c.Title })
               .SelectMany(c => c);

            imageViewModel.Products = products
              .Select(c => new List<string> { c.Id, c.Name })
              .SelectMany(c => c);

            imageViewModel.Exercises = exercises
             .Select(c => new List<string> { c.Id, c.Name })
             .SelectMany(c => c);

            imageViewModel.Programs = programs
            .Select(c => new List<string> { c.Id, c.Title })
            .SelectMany(c => c);

            return imageViewModel;
        }

        public async Task EditImageAsync(ImageAdminEditViewModel inputModel)
        {
            var image = await this.dbContext.Images
                  .FirstOrDefaultAsync(i => i.Id == inputModel.Id);

            if (image == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidImage));
            }

            image.IsDeleted = inputModel.IsDeleted;

            image.DeletedOn = inputModel.DeletedOn;

            image.CreatedOn = inputModel.CreatedOn;

            image.ModifiedOn = inputModel.ModifiedOn;

            image.Url = inputModel.Url;

            image.PostId = inputModel.PostId;

            image.ProductId = inputModel.ProductId;

            image.ProgramId = inputModel.ProgramId;

            image.ExerciseId = inputModel.ExerciseId;

            this.dbContext.Update(image);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IList<ImagesAdminViewModel>> GetAllImagesForAdminAsync()
        {
            var images = await this.dbContext.Images
                .ToListAsync();

            var imagesViewModel = this.mapper.Map<IList<ImagesAdminViewModel>>(images);

            return imagesViewModel;
        }

        public async Task<IEnumerable<string>> GetImagesByProductIdAsync(string id)
        {
            var images = await this.dbContext.Images
                .Where(i => i.ProductId == id)
                .Where(i => i.IsDeleted == false)
                .Select(i => i.Url)
                .ToListAsync();

            if (images == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidProductId, id));
            }

            return images;
        }

        public async Task CreateImageAsync(ImageAdminCreateViewModel inputModel)
        {
            var image = new Image
            {
                Url = inputModel.Url,
                ProductId = inputModel.ProductId,
                PostId = inputModel.PostId,
                ExerciseId = inputModel.ExerciseId,
                ProgramId = inputModel.ProgramId,
            };

            await this.dbContext.Images.AddAsync(image);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
