
using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Comments.Comments.Models;


namespace Blog.Core.Application.Features.Application.Comments.Comments.Interfaces
{
    public interface ICommentService : IBaseCompleteService<SaveCommentModel, CommentModel> 
    {
        Task<Result<List<CommentModel>>> GetCommentsByPostId(int postId);
        Task<Result> AddOrUnAddLikeToCommentAsync(int commentId, string userId);
    }
}
