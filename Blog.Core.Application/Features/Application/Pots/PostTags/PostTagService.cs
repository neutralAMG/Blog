
using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Pots.PostTags.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostTags.Models;
using Blog.Core.Application.Features.Application.Pots.PostTags.Validator;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Enums;

namespace Blog.Core.Application.Features.Application.Pots.PostTags
{
    public class PostTagService : BaseService<SavePostTagModel, PostTag>, IPostTagService
    {
        private readonly IPostTagRepository _postTagRepository;
        private readonly PostTagValidator _postTagValidator;

        public PostTagService(IPostTagRepository postTagRepository, IMapper mapper, PostTagValidator postTagValidator) : base(postTagRepository, mapper, postTagValidator)
        {
            _postTagRepository = postTagRepository;
            _postTagValidator = postTagValidator;
        }

        public async Task<Result> AddOrUnAddTagToPostAsync(int postId, int tagId)
        {


            if (await _postTagRepository.ExitsAsync(b => b.PostId == postId && b.TagId == tagId))
            {
                bool deleteIsSuccess = await _postTagRepository.DeleteAsync(postId, tagId);

                return deleteIsSuccess 
                    ? Result.Success() 
                    : ErrorTypess.OperationFaild.Because("Error while removing a tag from the post ");
            }

            return await base.SaveAsync(new()
            {
                PostId = postId,
                TagId = tagId,
            });
        }
    }
}
