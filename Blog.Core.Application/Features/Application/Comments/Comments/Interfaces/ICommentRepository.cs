using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Features.Application.Comments.Comments.Interfaces
{
    public interface ICommentRepository : IBaseCompleteRepository<Comment>
    {
        Task<List<Comment>> GetCommentsByPostId(int postId);    
    }
}
