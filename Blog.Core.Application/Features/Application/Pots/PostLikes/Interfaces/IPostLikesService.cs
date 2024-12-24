using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Pots.PostLikes.Models;


namespace Blog.Core.Application.Features.Application.Pots.PostLikes.Interfaces
{
    public interface IPostLikesService : IBaseService<SavePostLikeModel>
    {
        Task<Result> AddOrUnAddLikeToPostAsync(int postId, string userId);
    }
}
