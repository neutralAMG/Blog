using Blog.Core.Application.Core;

namespace Blog.Core.Application.Features.Application.UserData.UserFollow.Interfaces
{
    public interface IUserFollowRepository : IBaseCompleteRepository<Domain.Entities.UserFollow>
    {
        Task<bool> DeleteAsync(string followerId, string followeId);
    }
}
