namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models.BlogEntities;
    using MyCalisthenicApp.Models.BlogEntities.Enums;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Home;
    using MyCalisthenicApp.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;
        private readonly ICategoriesService categoriesService;

        public PostsService(
            MyCalisthenicAppDbContext dbContext,
            IMapper mapper,
            IUsersService usersService,
            ICategoriesService categoriesService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.usersService = usersService;
            this.categoriesService = categoriesService;
        }

        public async Task AddRatingAsync(string id)
        {
            var post = await this.dbContext.Post
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidPostId, id));
            }

            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            if (userFromDb == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidUserId, userId));
            }

            var userCredentials = userFromDb.FirstName + " " + userFromDb.LastName + ":" + userId;

            if (post.LikesUsersNames == null)
            {
                var likesUsersNames = new List<string>();

                post.LikesUsersNames = likesUsersNames;
            }

            if (!post.LikesUsersNames.Contains(userCredentials))
            {
                if (post.Rating == null)
                {
                    post.Rating = 1;
                }
                else
                {
                    post.Rating += 1;
                }

                post.LikesUsersNames.Add(userCredentials);
            }
            else if (post.LikesUsersNames.Contains(userCredentials))
            {
                if (post.Rating >= 1)
                {
                    post.Rating -= 1;
                }

                post.LikesUsersNames.Remove(userCredentials);
            }

            this.dbContext.Update(post);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostDetailsViewModel>> GetAllPostsAsync()
        {
            var posts = await this.dbContext.Post
                .Include(i => i.Images)
                .Include(au => au.Author)
                .Include(cm => cm.Comments)
                .Where(p => p.IsPublic == true)
                 .Where(c => c.IsDeleted == false)
                 .Where(c => c.Category.IsDeleted == false)
                .ToListAsync();

            var allPosts = this.mapper.Map<IEnumerable<PostDetailsViewModel>>(posts);

            return allPosts;
        }

        public async Task<IEnumerable<PostDetailsSidebarViewModel>> GetFourLatestPostsAsync()
        {
            var posts = await this.dbContext.Post
                 .Include(i => i.Images)
                 .Where(p => p.IsPublic == true)
                 .Where(p => p.IsDeleted == false)
                 .Where(p => p.Category.IsDeleted == false)
                 .OrderByDescending(p => p.CreatedOn)
                 .Take(4)
                 .ToListAsync();

            var postsViewModel = this.mapper.Map<IEnumerable<PostDetailsSidebarViewModel>>(posts);

            return postsViewModel;
        }

        public async Task<IEnumerable<PopularPostsHomeViewModel>> GetPopularPostsAsync()
        {
            var posts = await this.dbContext
                .Post.Include(a => a.Author)
                .Include(c => c.Category)
                .Include(i => i.Images)
                .Include(cm => cm.Comments)
                .Where(p => p.IsPublic == true)
                 .Where(p => p.IsDeleted == false)
                  .Where(p => p.Category.IsDeleted == false)
                .Take(8).ToListAsync();

            var postsViewModel = this.mapper.Map<IEnumerable<PopularPostsHomeViewModel>>(posts);

            return postsViewModel;
        }

        public bool GetPostById(string id)
        {
            return this.dbContext.Post
                .Where(p => p.IsDeleted == false)
                 .Where(p => p.Category.IsDeleted == false)
                 .Where(p => p.IsPublic == true).Any(p => p.Id == id);
        }

        public async Task<PostDetailsViewModel> GetPostDetailsByIdAsync(string id)
        {
            var post = await this.dbContext.Post
                 .Include(i => i.Images)
                .Include(au => au.Author)
                .Include(cm => cm.Comments)
                .Include(c => c.Category)
                .Where(p => p.Id == id)
                 .Where(c => c.IsDeleted == false)
                 .Where(c => c.IsPublic == true)
                 .Where(p => p.Category.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidPostId, id));
            }

            var postViewModel = this.mapper.Map<PostDetailsViewModel>(post);

            return postViewModel;
        }

        public async Task<IEnumerable<PostDetailsViewModel>> GetPostsBySearchAsync(SearchViewModel inputModel)
        {
            if (inputModel.Text == null || inputModel.Text.Length < 4)
            {
                return null;
            }
            else if (inputModel.Text.Length >= 4)
            {
                var posts = await this.dbContext.Post
               .Include(i => i.Images)
               .Include(au => au.Author)
               .Include(cm => cm.Comments)
               .Where(p => p.IsPublic == true)
                .Where(c => c.IsDeleted == false)
                .Where(p => p.Category.IsDeleted == false)
                .Where(p => p.Title.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Category.Name.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Description.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Author.FirstName.ToLower().Contains(inputModel.Text.ToLower()) ||
                 p.Author.LastName.ToLower().Contains(inputModel.Text.ToLower()))
                .ToListAsync();

                if (posts.Any())
                {
                    var allPosts = this.mapper.Map<IEnumerable<PostDetailsViewModel>>(posts);

                    return allPosts;
                }
                else
                {
                    return null;
                }
            }

            return Enumerable.Empty<PostDetailsViewModel>();
        }

        public async Task<IEnumerable<PostDetailsViewModel>> SortPostsByCategoryAsync(string sort)
        {
            Enum.TryParse(sort, true, out CategoryType postType);

            var sortedPosts = await this.dbContext.Post
                 .Include(i => i.Images)
                 .Include(au => au.Author)
                 .Include(cm => cm.Comments)
                 .Include(c => c.Category)
                 .Where(p => p.IsDeleted == false)
                 .Where(p => p.IsPublic == true)
                 .Where(p => p.Category.IsDeleted == false)
                 .Where(p => p.Type == postType)
                 .ToListAsync();

            var sortedPostsViewModel = this.mapper.Map<IEnumerable<PostDetailsViewModel>>(sortedPosts);

            return sortedPostsViewModel;
        }

        public async Task<IList<PostsAdminViewModel>> GetAllPostsForAdminAsync()
        {
            var posts = await this.dbContext.Post
                 .Include(p => p.Author)
                 .Include(p => p.Category)
                 .Include(p => p.Images)
                 .ToListAsync();

            var postsViewModel = this.mapper.Map<IList<PostsAdminViewModel>>(posts);

            return postsViewModel;
        }

        public async Task<IList<string>> GetAllLikesByPostIdAsync(string id)
        {
            var post = await this.dbContext.Post
                 .Where(c => c.Id == id)
                 .FirstOrDefaultAsync();

            if (post == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidPostId, id));
            }

            if (post.LikesUsersNames == null)
            {
                post.LikesUsersNames = new List<string>();
            }

            var likes = post.LikesUsersNames;

            return likes;
        }

        public async Task<PostAdminEditViewModel> GetPostForAdminByIdAsync(string id)
        {
            var post = await this.dbContext.Post
                 .Include(p => p.Category)
                 .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidPostId, id));
            }

            var categories = this.categoriesService.GetAllPostCategories();

            var postViewModel = this.mapper.Map<PostAdminEditViewModel>(post);

            postViewModel.Categories = categories;

            return postViewModel;
        }

        public async Task EditPostAsync(PostAdminEditViewModel inputModel)
        {
            var post = await this.dbContext.Post
                  .Include(p => p.Category)
                  .FirstOrDefaultAsync(p => p.Id == inputModel.Id);

            if (post == null)
            {
                throw new ArgumentNullException(string.Format(ServicesConstants.InvalidPostId, inputModel.Id));
            }

            Enum.TryParse(inputModel.Type, true, out CategoryType postType);

            post.IsDeleted = inputModel.IsDeleted;

            post.DeletedOn = inputModel.DeletedOn;

            post.CreatedOn = inputModel.CreatedOn;

            post.ModifiedOn = inputModel.ModifiedOn;

            post.Title = inputModel.Title;

            post.Description = inputModel.Description;

            post.AuthorId = inputModel.AuthorId;

            post.CategoryId = inputModel.CategoryId;

            post.Category.Name = inputModel.CategoryName;

            post.Rating = inputModel.Rating;

            post.Type = postType;

            post.VideoUrl = inputModel.VideoUrl;

            post.IsPublic = inputModel.IsPublic;

            this.dbContext.Update(post);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreatePostAsync(PostAdminCreateViewModel inputModel)
        {
            var post = new Post
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                AuthorId = inputModel.AuthorId,
                CategoryId = inputModel.CategoryId,
                Rating = inputModel.Rating,
                Type = inputModel.Type,
                VideoUrl = inputModel.VideoUrl,
            };

            await this.dbContext.Post.AddAsync(post);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
