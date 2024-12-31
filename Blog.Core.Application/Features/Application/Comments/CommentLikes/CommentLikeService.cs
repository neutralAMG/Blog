
using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Comments.CommentLikes.Interfaces;
using Blog.Core.Application.Features.Application.Comments.CommentLikes.Models;
using Blog.Core.Application.Utls;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Enums;

namespace Blog.Core.Application.Features.Application.Comments.CommentLikes
{
    public class CommentLikeService : BaseService<SaveCommentLikeModel, CommentLike>, ICommentLikeService
    {
        private readonly ICommentLikeRepositiory _commentLikeRepositiory;
        private readonly SessionManager _sessionManager;

        public CommentLikeService(ICommentLikeRepositiory commentLikeRepositiory, IMapper mapper, SessionManager sessionManager) : base(commentLikeRepositiory, mapper)
        {
            _commentLikeRepositiory = commentLikeRepositiory;
            _sessionManager = sessionManager;
        }

        public async Task<Result> AddOrUnAddLikeToCommentAsync(string userId, int commentId)
        {
            if (!await _commentLikeRepositiory.ExitsAsync(c => c.CommentId == commentId && c.UserId == userId))
            {
                bool isDeleteSuccessfull = await _commentLikeRepositiory.DeleteAsync(commentId, userId);
                return isDeleteSuccessfull ? Result.Success() : ErrorTypess.OperationFaild.Because("Error while removing the like"); 
            }
            return await base.SaveAsync(new() { CommentId = commentId , UserId = userId});
        }

        public async  override Task<Result> DeleteAsync(int id)
        {
            if (!await _commentLikeRepositiory.ExitsAsync(p => p.Id == id && p.UserId == _sessionManager.GetUserFromSession().Id))
                return ErrorTypess.NoAuthorize.Because("The comment being deleted does not belong to the current user");

            return await base.DeleteAsync(id);
        }
    }
}
