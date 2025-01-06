using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Features.Application.Pots.Pots.Interfaces
{
    public interface IPostRepository : IBaseCompleteRepository<Domain.Entities.Post>
    {
        Task<List<Domain.Entities.Post>> GetByTagIdAsync(int tagId);
    }
}
