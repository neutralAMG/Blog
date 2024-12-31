using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Comments.CommentLikes.Interfaces
{
    public interface ICommentLikeRepositiory : IBaseRepository<CommentLike>, IDeleteUserMToMRelationshipEntity
    {
        new Task<bool> DeleteAsync(int commentId, string userId);
    }
}
