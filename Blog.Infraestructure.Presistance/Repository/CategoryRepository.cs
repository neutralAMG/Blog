using Blog.Core.Application.Interfaces.Repositories.Persistance;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;


namespace Blog.Infraestructure.Presistance.Repository
{
	public class CategoryRepository : BaseSoftDeleteCompleteRepository<Category>, ICategoryRepository
	{
		private readonly ApplicationContext _context;

		public CategoryRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<bool> UpdateAsync(Category entity)
		{
			if (!await ExitsAsync(c => c.Id == entity.Id)) return false;

			Category categoryToBeUpdated = await _context.Categories.FindAsync(entity.Id);
			categoryToBeUpdated.Name = entity.Name;
			categoryToBeUpdated.Description = entity.Description;
			categoryToBeUpdated.LastUpdateDate = DateTime.UtcNow;
			categoryToBeUpdated.LastUpdatedBy = entity.LastUpdatedBy;
			return await base.UpdateAsync(categoryToBeUpdated);
		}
	}
}
