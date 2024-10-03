
using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Comments.Comments.Models;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Comments.Comments.Interfaces
{
    public interface ICommentService : IBaseCompleteService<SaveCommentModel, CommentModel> 
    {
        Task<Result<List<CommentModel>>> GetCommentsByPostId(int postId);
    }
}
