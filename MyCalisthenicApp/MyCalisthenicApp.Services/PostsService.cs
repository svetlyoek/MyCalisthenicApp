namespace MyCalisthenicApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Services.Common;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;

        public PostsService(MyCalisthenicAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PostDetailsViewModel>> GetAllPostsAsync()
        {
            var posts = await this.dbContext.Post
                .Include(i => i.Images)
                .Include(au => au.Author)
                .Include(cm => cm.Comments)
                .Where(p => p.IsPublic == true)
                 .Where(c => c.IsDeleted == false)
                .ToListAsync();

            var allPosts = this.mapper.Map<IEnumerable<PostDetailsViewModel>>(posts);

            return allPosts;
        }

        public async Task<IEnumerable<PostDetailsSidebarViewModel>> GetFourLatestPosts()
        {
            var posts = await this.dbContext.Post
                 .Include(i => i.Images)
                 .Where(p => p.IsPublic == true)
                 .Where(c => c.IsDeleted == false)
                 .OrderByDescending(p => p.CreatedOn)
                 .Take(4)
                 .ToListAsync();

            var postsViewModel = this.mapper.Map<IEnumerable<PostDetailsSidebarViewModel>>(posts);

            return postsViewModel;
        }

        // TODO Take only most rated posts
        public async Task<IEnumerable<PopularPostsHomeViewModel>> GetPopularPostsAsync()
        {
            var posts = await this.dbContext
                .Post.Include(a => a.Author)
                .Include(c => c.Category)
                .Include(i => i.Images)
                .Include(cm => cm.Comments)
                .Where(p => p.IsPublic == true)
                 .Where(c => c.IsDeleted == false)
                .Take(8).ToListAsync();

            var postsViewModel = this.mapper.Map<IEnumerable<PopularPostsHomeViewModel>>(posts);

            return postsViewModel;
        }

        public async Task<PostDetailsViewModel> GetPostDetailsById(string id)
        {
            var post = await this.dbContext.Post
                .Where(p => p.Id == id)
                 .Where(c => c.IsDeleted == false)
                 .Where(c => c.IsPublic == true)
                .Include(i => i.Images)
                .Include(au => au.Author)
                .Include(cm => cm.Comments)
                .Include(c => c.Category)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                throw new NullReferenceException(string.Format(ServicesConstants.InvalidPost, id));
            }

            var postViewModel = this.mapper.Map<PostDetailsViewModel>(post);

            return postViewModel;
        }

        public async Task<IEnumerable<PostDetailsViewModel>> SortPostsByCategoryAsync(string sort)
        {
            var sortedPosts = await this.dbContext
                 .Post.Include(i => i.Images)
                 .Include(au => au.Author)
                 .Include(cm => cm.Comments)
                 .Include(c => c.Category)
                 .Where(p => p.IsDeleted == false)
                 .Where(p => p.IsPublic == true)
                 .Where(p => p.Category.Name == sort)
                 .ToListAsync();

            var sortedPostsViewModel = this.mapper.Map<IEnumerable<PostDetailsViewModel>>(sortedPosts);

            return sortedPostsViewModel;
        }
    }
}
