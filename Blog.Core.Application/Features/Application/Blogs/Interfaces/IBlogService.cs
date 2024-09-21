using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Blogs.Models;


namespace Blog.Core.Application.Features.Application.Blogs.Interfaces
{
    public interface IBlogService : IBaseCompleteService<SaveBlogModel, BlogModel>
    {
    }
}
