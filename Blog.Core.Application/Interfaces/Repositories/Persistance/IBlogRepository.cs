

using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Interfaces.Repositories.Persistance
{
	public interface IBlogRepository : IBaseCompleteRepository<UserBlog>
	{
		Task<List<UserBlog>> GetByCaregoryId(int categoryId);
	}
}
