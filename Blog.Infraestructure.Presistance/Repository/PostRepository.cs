

using Blog.Core.Application.Interfaces.Repositories.Persistance;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Presistance.Repository
{
	public class PostRepository : BaseSoftDeleteCompleteRepository<Post>, IPostRepository
	{
		private readonly ApplicationContext _context;

		public PostRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<List<Post>> GetAllAsync()
		{
			return await _context.Post.AsSplitQuery()
				.Include(p => p.PostTags)
				.Include(p => p.PostLikes)
				.Include(p => p.Blog).ToListAsync();
		}

		public override async Task<Post> GetByIdAsync(int id)
		{
			return _context.Post.AsSplitQuery()
				.Include(p => p.PostTags)
				.Include(p => p.PostLikes)
				.Include(p => p.Comments)
				.Where(p => p.Id == id).FirstOrDefault();
		}

		public async Task<List<Post>> GetByTagIdAsync(int tagId)
		{
			return await _context.Post.AsSplitQuery()
				.Include(p => p.PostTags)
				.Include(p => p.PostLikes)
				.Include(p => p.Blog)
				.Where(p => p.PostTags.Any(p => p.TagId == tagId)).ToListAsync();
		}

		public override  IQueryable<Post> GetQueribleEntity()
		{
			return  _context.Post.AsSplitQuery()
				.Include(p => p.PostTags)
				.Include(p => p.PostLikes)
				.Include(p => p.Blog);
		}

		public override async Task<bool> UpdateAsync(Post entity)
		{
			if (!await ExitsAsync(p => p.Id == entity.Id)) return false;

			Post postToBeUpdated = await _context.Post.FindAsync(entity.Id);

			postToBeUpdated.Title = entity.Title;

			postToBeUpdated.PostContent = entity.PostContent;
			postToBeUpdated.LastUpdateDate = DateTime.UtcNow;
			postToBeUpdated.LastUpdatedBy = entity.LastUpdatedBy;

			return await base.UpdateAsync(postToBeUpdated);
		}
	}
}
