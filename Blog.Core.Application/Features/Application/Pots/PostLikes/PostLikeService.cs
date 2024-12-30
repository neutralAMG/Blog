

using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Pots.PostLikes.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostLikes.Models;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Enums;

namespace Blog.Core.Application.Features.Application.Pots.PostLikes
{
    public class PostLikeService : BaseService<SavePostLikeModel, PostLike>, IPostLikesService
    {
        private readonly IPostLikeRepository _postLikeRepository;

        public PostLikeService(IPostLikeRepository postLikeRepository, IMapper mapper) : base(postLikeRepository, mapper)
        {
            _postLikeRepository = postLikeRepository;
        }

        public async Task<Result> AddOrUnAddLikeToPostAsync(int postId, string userId)
        {
            if (string.IsNullOrEmpty(userId))
                ErrorTypess.ValidationMissMatch.Because("User Id can not be null");

            if (postId <= 0)
                ErrorTypess.ValidationMissMatch.Because("Post id was empty or invalid");

            if (await _postLikeRepository.ExitsAsync(b => b.UserId == userId && b.PostId == postId))
            {
                bool deleteIsSuccess = await _postLikeRepository.DeleteAsync(postId,userId);
                return deleteIsSuccess ? Result.Success() : ErrorTypess.OperationFaild.Because("Error while removing the post like");
            }

            return await base.SaveAsync(new()
            {
                PostId = postId,
                UserId = userId,
            });
        }
    }
}
