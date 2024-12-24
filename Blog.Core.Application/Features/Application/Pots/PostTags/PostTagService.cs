
using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Pots.PostTags.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostTags.Models;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Enums;

namespace Blog.Core.Application.Features.Application.Pots.PostTags
{
    public class PostTagService : BaseService<SavePostTagModel, PostTag>, IPostTagService
    {
        private readonly IPostTagRepository _postTagRepository;

        public PostTagService(IPostTagRepository postTagRepository, IMapper mapper) : base(postTagRepository, mapper)
        {
            _postTagRepository = postTagRepository;
        }

        public async Task<Result> AddOrUnAddTagToPostAsync(int postId, int tagId)
        {
            if (tagId <= 0)
                ErrorTypess.ValidationMissMatch.Because("tag Id can not be null");
            if (postId <= 0)
                ErrorTypess.ValidationMissMatch.Because("post id was empty or invalid");

            if (await _postTagRepository.ExitsAsync(b => b.PostId == postId && b.TagId == tagId))
            {
                bool deleteIsSuccess = await _postTagRepository.DeleteAsync(postId, tagId);
                return deleteIsSuccess ? Result.Success() : ErrorTypess.OperationFaild.Because("Error while removing a tag from the post ");
            }

            return await base.SaveAsync(new()
            {
                PostId = postId,
                TagId = tagId,
            });
        }
    }
}
