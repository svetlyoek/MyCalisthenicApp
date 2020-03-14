namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
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

        // TODO Take only most rated posts
        public async Task<IEnumerable<PopularPostsHomeViewModel>> GetPopularPostsAsync()
        {
            var posts = await this.dbContext
                .Post.Include(a => a.Author)
                .Include(c => c.Category)
                .Include(i => i.Images)
                .Include(cm => cm.Comments)
                .Take(8).ToListAsync();

            var postsViewModel = this.mapper.Map<IEnumerable<PopularPostsHomeViewModel>>(posts);

            return postsViewModel;
        }
    }
}
