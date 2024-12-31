
using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Comments.Comments.Interfaces;
using Blog.Core.Application.Features.Application.UserData.UserFollow.Interfaces;
using Blog.Core.Application.Features.Application.UserData.UserFollow.Models;
using Blog.Core.Application.Utls;
using Blog.Core.Domain.Enums;

namespace Blog.Core.Application.Features.Application.UserData.UserFollow
{
    public class UserFollowService : BaseCompleteService<SaveUserFollowModel,UserModel, Domain.Entities.UserFollow>, IUserFollowService
    {
        private readonly IUserFollowRepository _userFollowRepository;
        private readonly SessionManager _sessionManager;

        public UserFollowService(IUserFollowRepository userFollowRepository, IMapper mapper, SessionManager sessionManager) : base(userFollowRepository, mapper)
        {
            _userFollowRepository = userFollowRepository;
            _sessionManager = sessionManager;
        }
        public override async Task<Result<List<UserModel>>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }
        public override async Task<Result<UserModel>> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }
        public async Task<Result> DeleteAsync(string followerId, string followeId)
        {
            if (!await _userFollowRepository.ExitsAsync(p => p.FollowerId == _sessionManager.GetUserFromSession().Id && p.FolloweId == followeId))
                return ErrorTypess.NoAuthorize.Because("You do not follow this person");

            bool IsDeleteASuccess = await _userFollowRepository.DeleteAsync(followerId, followeId);

            return !IsDeleteASuccess ? ErrorTypess.OperationFaild.Because("Error while unfollowimg the user") : Result.Success();
        }
    }
}
