namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CommentsService(MyCalisthenicAppDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Comment> CreateCommentAsync(string id, CommentInputViewModel commentModel)
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userFromDb = await this.dbContext.Users.FindAsync(userId);
            Comment comment = null;

            if (this.dbContext.Products.Any(p => p.Id == id))
            {
                comment = new Comment
                {
                    Text = commentModel.Text,
                    AuthorId = userId,
                    Author = userFromDb,
                    ProductId = id,
                };
            }

            if (this.dbContext.Post.Any(p => p.Id == id))
            {
                comment = new Comment
                {
                    Text = commentModel.Text,
                    AuthorId = userId,
                    Author = userFromDb,
                    PostId = id,
                };
            }

            if (this.dbContext.Programs.Any(pc => pc.Id == id))
            {
                comment = new Comment
                {
                    Text = commentModel.Text,
                    AuthorId = userId,
                    Author = userFromDb,
                    ProgramId = id,
                };
            }

            await this.dbContext.Comments.AddAsync(comment);

            await this.dbContext.SaveChangesAsync();

            return comment;
        }

        public async Task<IEnumerable<CommentViewModel>> GetCommentsByProgramIdAsync(string id)
        {
            var comments = await this.dbContext
                 .Comments
                 .Include(u => u.Author)
                 .Where(c => c.ProgramId == id)
                 .Where(c => c.IsDeleted == false)
                 .ToListAsync();

            var commentsViewModel = this.mapper.Map<IEnumerable<CommentViewModel>>(comments);

            return commentsViewModel;
        }

        public async Task<IEnumerable<CommentViewModel>> GetCommentsByPostIdAsync(string id)
        {
            var comments = await this.dbContext
                .Comments
                .Include(u => u.Author)
                .Where(c => c.PostId == id)
                .Where(c => c.IsDeleted == false)
                .ToListAsync();

            var commentsViewModel = this.mapper.Map<IEnumerable<CommentViewModel>>(comments);

            return commentsViewModel;
        }

        public async Task<IEnumerable<CommentViewModel>> GetCommentsByProductIdAsync(string id)
        {
            var comments = await this.dbContext
                 .Comments
                 .Include(u => u.Author)
                 .Where(c => c.ProductId == id)
                  .Where(c => c.IsDeleted == false)
                 .ToListAsync();

            var commentsViewModel = this.mapper.Map<IEnumerable<CommentViewModel>>(comments);

            return commentsViewModel;
        }

        public async Task<string> AddRatingAsync(string id)
        {
            string returnId = string.Empty;

            var comment = await this.dbContext.Comments.
                FirstOrDefaultAsync(p => p.Id == id);

            if (comment.Rating == null)
            {
                comment.Rating = 1;
            }
            else
            {
                comment.Rating += 1;
            }

            if (comment.PostId != null)
            {
                returnId = comment.PostId;
            }

            if (comment.ProductId != null)
            {
                returnId = comment.ProductId;
            }

            if (comment.ProgramId != null)
            {
                returnId = comment.ProgramId;
            }

            this.dbContext.Update(comment);

            await this.dbContext.SaveChangesAsync();

            return returnId;
        }
    }
}
