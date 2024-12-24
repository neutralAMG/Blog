using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Pots.PostLikes.Interfaces
{
    public interface IPostLikeRepository : IBaseRepository<PostLike> , IDeleteUserMToMRelationshipEntity
    {
        Task<bool> DeleteAsync(int postId, string userId);
    }
}
