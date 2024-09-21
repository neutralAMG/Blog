using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Blogs.Interfaces
{
    public interface IBlogRepository : IBaseCompleteRepository<UserBlog>
    {
        Task<List<UserBlog>> GetByCaregoryId(int categoryId);
    }
}
