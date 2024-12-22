using Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Repository
{
    public class BlogFavoriteRepository : BaseRepository<BlogFavorite>, IBlogFavoriteRepository
	{
        private readonly ApplicationContext _context;

        public BlogFavoriteRepository(ApplicationContext context) : base(context) =>_context = context;
      

        public async Task<bool> DeleteAsync(string userId, int blogId)
        {
            BlogFavorite blogFavoriteToDelete = await _context.BlogFavorites.FirstOrDefaultAsync(b => b.UserId == userId && b.BlogId == blogId);

            return blogFavoriteToDelete != null ? await base.DeleteAsync(blogFavoriteToDelete.Id) : false;
        }
    }
}
