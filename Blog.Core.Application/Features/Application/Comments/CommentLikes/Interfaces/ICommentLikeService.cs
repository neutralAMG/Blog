

using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Comments.CommentLikes.Models;

namespace Blog.Core.Application.Features.Application.Comments.CommentLikes.Interfaces
{
    public interface ICommentLikeService : IBaseService<SaveCommentLikeModel>
    {
        Task<Result> AddOrUnAddLikeToCommentAsync(string userId, int commentId);
    }
}
