using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Blogs.Blogs.Models;

namespace Blog.Core.Application.Features.Application.Blogs.Blogs.Interfaces
{
    public interface IBlogService : IBaseCompleteService<SaveBlogModel, BlogModel>
    {
        Task<Result<List<BlogModel>>> GetByCaregoryId(int categoryId);
        Task<Result<List<BlogModel>>> GetUserBlogAsync(string userId);
    }
}
