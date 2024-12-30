

using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.UserData.UserFollow.Models;

namespace Blog.Core.Application.Features.Application.UserData.UserFollow.Interfaces
{
    internal interface IUserFollowService : IBaseCompleteService<SaveUserFollowModel,UserModel>
    {
        Task<Result> DeleteAsync(string followerId, string followeId);
    }
}
