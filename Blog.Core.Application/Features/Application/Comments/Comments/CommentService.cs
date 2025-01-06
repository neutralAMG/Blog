
using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Comments.Comments.Interfaces;
using Blog.Core.Application.Features.Application.Comments.Comments.Models;
using Blog.Core.Domain.Enums;
using Blog.Core.Domain.Entities;
using Blog.Core.Application.Utls;
using Blog.Core.Application.Features.Application.Comments.CommentLikes.Interfaces;
using Blog.Core.Application.Features.Application.Comments.Comments.Validator;

namespace Blog.Core.Application.Features.Application.Comments.Comments
{
    public class CommentService : BaseCompleteService<SaveCommentModel, CommentModel, Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly CommentValidator _commentValidator;
        private readonly ICommentLikeService _commentLikeService;
        private readonly SessionManager _sessionManager;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, CommentValidator commentValidator,ICommentLikeService commentLikeService, SessionManager sessionManager) : base(commentRepository, mapper, commentValidator)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _commentValidator = commentValidator;
            _commentLikeService = commentLikeService;
            _sessionManager = sessionManager;
        }
        public async override Task<Result> UpdateAsync(SaveCommentModel entity)
        {
            if (!await _commentRepository.ExitsAsync(p => p.Id == entity.Id  && p.UserId == _sessionManager.GetUserFromSession().Id))
                return ErrorTypess.NoAuthorize.Because("The comment being deleted does not belong to the current user");

            return await base.UpdateAsync(entity);
        }

        public async override Task<Result> DeleteAsync(int id)
        {
            if (!await _commentRepository.ExitsAsync(p => p.Id == id && p.UserId == _sessionManager.GetUserFromSession().Id))
                return ErrorTypess.NoAuthorize.Because("The comment being deleted does not belong to the current user");

            return await base.DeleteAsync(id);
        }
        public async Task<Result<List<CommentModel>>> GetCommentsByPostId(int postId)
        {
            if (postId <= 0)
                return ErrorTypess.ValidationMissMatch.Because("the id was ether empty or invalid");

                List<Comment> commentsGetted = await _commentRepository.GetCommentsByPostId(postId);

                return _mapper.MapSafely<List<CommentModel>>(commentsGetted);
        }

        public Task<Result> AddOrUnAddLikeToCommentAsync(int commentId, string userId) => _commentLikeService.AddOrUnAddLikeToCommentAsync(userId,commentId);

        public async Task<Result> ReplyAsync(SaveCommentModel saveModel)
        {
            if (saveModel.ParentCommentId <= 0)
                return ErrorTypess.ValidationMissMatch.Because("The comment id being replied to is empty or invalid");

            Result validationResult = _commentValidator.IsModelValid(saveModel);

            return await base.SaveAsync(saveModel);
        }
    }
}
