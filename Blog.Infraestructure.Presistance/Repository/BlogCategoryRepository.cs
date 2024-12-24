

using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Repository
{
    public class BlogCategoryRepository : BaseRepository<BlogCategory>, IBlogCategoryRepository
	{
        private readonly ApplicationContext _context;

        public BlogCategoryRepository(ApplicationContext context) : base(context) => _context = context;
       

        public async Task<bool> DeleteAsync(int blogId, int categoryId)
        {
            BlogCategory blogCategoryToDelete = await _context.BlogCategories.FirstOrDefaultAsync(b => b.CategoryId == categoryId && b.BlogId == blogId);

            return blogCategoryToDelete != null ? await base.DeleteAsync(blogCategoryToDelete.Id) : false;
        }
    }
}
