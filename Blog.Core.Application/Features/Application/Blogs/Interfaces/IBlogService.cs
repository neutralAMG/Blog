using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Blogs.Models;
using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Features.Application.Blogs.Interfaces
{
    public interface IBlogService : IBaseCompleteService<SaveBlogModel, BlogModel>
    {
		Task<Result<List<BlogModel>>> GetByCaregoryId(int categoryId);
		Task<Result<List<BlogModel>>> GetUserBlogAsync(string userId);
	}
}
