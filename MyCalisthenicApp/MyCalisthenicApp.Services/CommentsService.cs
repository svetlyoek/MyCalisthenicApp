namespace MyCalisthenicApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly MyCalisthenicAppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public CommentsService(MyCalisthenicAppDbContext dbContext, IMapper mapper, IUsersService usersService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        public async Task<Comment> CreateCommentAsync(string id, CommentInputViewModel commentModel)
        {
            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

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

            var userId = this.usersService.GetLoggedUserId();

            var userFromDb = await this.usersService.GetLoggedUserByIdAsync(userId);

            var userCredentials = userFromDb.FirstName + " " + userFromDb.LastName + ":" + userId;

            if (comment.LikesUsersNames == null)
            {
                var likesUsersNames = new List<string>();

                comment.LikesUsersNames = likesUsersNames;
            }

            if (!comment.LikesUsersNames.Contains(userCredentials))
            {
                if (comment.Rating == null)
                {
                    comment.Rating = 1;
                }
                else
                {
                    comment.Rating += 1;
                }

                comment.LikesUsersNames.Add(userCredentials);
            }
            else if (comment.LikesUsersNames.Contains(userCredentials))
            {
                if (comment.Rating >= 1)
                {
                    comment.Rating -= 1;
                }

                comment.LikesUsersNames.Remove(userCredentials);
            }

            this.dbContext.Update(comment);

            await this.dbContext.SaveChangesAsync();

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

        public async Task<IList<string>> GetAllLikesByCommentIdAsync(string id)
        {
            var comment = await this.dbContext.Comments
                 .Where(c => c.Id == id)
                 .FirstOrDefaultAsync();

            if (comment.LikesUsersNames == null)
            {
                comment.LikesUsersNames = new List<string>();
            }

            var likes = comment.LikesUsersNames;

            return likes;
        }

        public async Task<CommentAdminEditViewModel> GetCommentByIdAsync(string id)
        {
            var comment = await this.dbContext.Comments
                 .FirstOrDefaultAsync(c => c.Id == id);

            var commentViewModel = this.mapper.Map<CommentAdminEditViewModel>(comment);

            return commentViewModel;
        }

        public async Task EditCommentAsync(CommentAdminEditViewModel inputModel)
        {
            var comment = await this.dbContext.Comments
                .FirstOrDefaultAsync(c => c.Id == inputModel.Id);

            comment.IsDeleted = inputModel.IsDeleted;

            comment.DeletedOn = inputModel.DeletedOn;

            comment.ModifiedOn = inputModel.ModifiedOn;

            comment.CreatedOn = inputModel.CreatedOn;

            comment.Text = inputModel.Text;

            comment.AuthorId = inputModel.AuthorId;

            comment.Rating = inputModel.Rating;

            comment.PostId = inputModel.PostId;

            comment.ProductId = inputModel.ProductId;

            comment.ProgramId = inputModel.ProgramId;

            this.dbContext.Update(comment);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
