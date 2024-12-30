using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Pots.Pots.Interfaces;
using Blog.Core.Application.Features.Application.Pots.Pots.Models;
using Blog.Core.Domain.Enums;
using Blog.Core.Domain.Entities;
using Blog.Core.Application.Utls;

namespace Blog.Core.Application.Features.Application.Pots.Pots
{
    public class PostService : BaseCompleteService<SavePostModel, PostModel, Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly SessionManager _sessionManager;

        public PostService(IPostRepository postRepository, IMapper mapper, SessionManager sessionManager) : base(postRepository, mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public  override async Task<Result> UpdateAsync(SavePostModel entity)
        {
            if (!await _postRepository.ExitsAsync(p => p.Id == entity.Id && p.Blog.UserId == _sessionManager.GetUserFromSession().Id))
                return ErrorTypess.NoAuthorize.Because("The post being updated does not belogn to the current user");

            return await base.UpdateAsync(entity);
        }
        public override async Task<Result> DeleteAsync(int id)
        {
            if (!await _postRepository.ExitsAsync(p => p.Id == id && p.Blog.UserId == _sessionManager.GetUserFromSession().Id))
                return ErrorTypess.NoAuthorize.Because("The post being deleted does not belogn to the current user");

            return await base.DeleteAsync(id);
        }

        public async override Task<Result> SaveAsync(SavePostModel saveModel)
        {
            if (!_sessionManager.IsTheUserInSession())
                return ErrorTypess.NoAutenticated.Because("there is no user loged in");

            return await base.SaveAsync(saveModel);
        }
        public async Task<Result<List<PostModel>>> GetByTagIdAsync(int tagId)
        {
            if (tagId <= 0)
                return ErrorTypess.ValidationMissMatch.Because("the tag id was ether empty or invalid");

            List<Post> potsGetted = await _postRepository.GetByTagIdAsync(tagId);

            return _mapper.MapSafely<List<PostModel>>(potsGetted);
        }
    }
}
