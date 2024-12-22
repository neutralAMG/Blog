

using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Models;

namespace Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Interfaces
{
    public interface IBlogFavoriteService : IBaseService<SaveBlogFavoriteModel>
    {
        Task<Result> AddOrUnAddBlogToFavoriteAsync(string userId, int blogId);
    }
}
