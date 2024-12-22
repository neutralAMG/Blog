using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Interfaces
{
    public interface IBlogFavoriteRepository : IBaseRepository<BlogFavorite>
    {
        Task<bool> DeleteAsync(string userId, int blogId);
    }
}
