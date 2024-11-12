using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Features.Application.Pots.Pots.Interfaces
{
    public interface IPostRepository : IBaseCompleteRepository<Post>
    {
        Task<List<Post>> GetByTagIdAsync(int tagId);
    }
}
