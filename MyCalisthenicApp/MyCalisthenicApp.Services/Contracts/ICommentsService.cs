namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.ViewModels.Comments;

    public interface ICommentsService
    {
        Task<IEnumerable<CommentViewModel>> GetCommentsByProgramIdAsync(string id);

        Task<IEnumerable<CommentViewModel>> GetCommentsByProductIdAsync(string id);

        Task<IEnumerable<CommentViewModel>> GetCommentsByPostIdAsync(string id);

        Task<Comment> CreateCommentAsync(string id, CommentInputViewModel commentModel);

        Task<string> AddRatingAsync(string id);
    }
}
