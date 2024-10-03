using Blog.Core.Application.Features.Application.Blogs.Blogs.Interfaces;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Repository
{
    public class BlogRepository : BaseCompleteRepository<UserBlog>, IBlogRepository
	{
		private readonly ApplicationContext _context;


		public BlogRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<List<UserBlog>> GetAllAsync()
		{
			return  await _context.UserBlogs.AsSplitQuery()
				.Include(b => b.BlogFavorites)
				.Include(b => b.BlogCategories).ToListAsync();
		}

		public async Task<List<UserBlog>> GetByCaregoryIdAsync(int categoryId)
		{
			return await _context.UserBlogs.AsSplitQuery()
				.Include(b => b.BlogFavorites)
				.Include(b => b.BlogCategories)
				.Where(b => b.BlogCategories
				.Any(b => b.CategoryId == categoryId)).ToListAsync();
		}

		public override async Task<UserBlog> GetByIdAsync(int id)
		{
			return await _context.UserBlogs.AsSplitQuery()
				.Include(b => b.BlogFavorites)
				.Include(b => b.BlogCategories)
				.Include(b => b.Posts).FirstOrDefaultAsync(b => b.Id == id,default);
		}

		public override IQueryable<UserBlog> GetQueribleEntity()
		{
			return _context.UserBlogs.AsSplitQuery()
				.Include(b => b.BlogFavorites)
				.Include(b => b.BlogCategories)
				.Include(b => b.Posts);
		}

		public async Task<List<UserBlog>> GetUserBlogAsync(string userId)
		{
			return await _context.UserBlogs.AsSplitQuery()
				.Include(b => b.BlogFavorites)
				.Include(b => b.BlogCategories)
				.Include(b => b.Posts).Where(b => b.UserId == userId).ToListAsync();
		}

		public override async Task<bool> UpdateAsync(UserBlog entity)
		{
			if (!await ExitsAsync(b => b.Id == entity.Id)) return false;
			UserBlog blogToBeUpdated = await _context.UserBlogs.FindAsync(entity.Id);

			blogToBeUpdated.Title = entity.Title;

			blogToBeUpdated.Summary = entity.Summary;


			return await base.UpdateAsync(blogToBeUpdated);
		}
	}
}
