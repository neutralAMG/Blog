

using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;

namespace Blog.Infraestructure.Presistance.Repository
{
    public class BlogCategoryRepository : BaseRepository<BlogCategory>, IBlogCategoryRepository
	{
		public BlogCategoryRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
