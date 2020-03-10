namespace MyCalisthenicApp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyCalisthenicApp.ViewModels.Comments;

    public interface ICommentsService
    {
        Task<IEnumerable<CommentViewModel>> GetCommentsByCategoryId(string id);

        Task CreateCommentAsync(string id, CommentInputViewModel commentModel);
    }
}
