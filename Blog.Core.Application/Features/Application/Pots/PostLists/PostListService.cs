using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Pots.PostLists.Interfaces;
using Blog.Core.Application.Features.Application.Pots.PostLists.Models;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Enums;


namespace Blog.Core.Application.Features.Application.Pots.PostLists
{
    public class PostListService : BaseService<SavePostListModel, PostList>, IPostListService
    {
        private readonly IPostListRepository _postListRepository;

        public PostListService(IPostListRepository postListRepository, IMapper mapper) : base(postListRepository, mapper)
        {
            _postListRepository = postListRepository;
        }

        public async Task<Result> AddOrUnAddPostToListAsync(int postId, int listId)
        {
            if (listId <= 0)
                ErrorTypess.ValidationMissMatch.Because("list Id can not be null");
            if (postId <= 0)
                ErrorTypess.ValidationMissMatch.Because("post id was empty or invalid");

            if (await _postListRepository.ExitsAsync(b => b.PostId == postId && b.UserListId == listId))
            {
                bool deleteIsSuccess = await _postListRepository.DeleteAsync(postId, listId);
                return deleteIsSuccess ? Result.Success() : ErrorTypess.OperationFaild.Because("Error while removing a post from the list ");
            }

            return await base.SaveAsync(new()
            {
                PostId = postId,
                UserListId = listId,
            });
        }
    }
}
