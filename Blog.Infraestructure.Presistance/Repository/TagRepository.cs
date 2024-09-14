using Blog.Core.Application.Interfaces.Repositories.Persistance;
using Blog.Core.Domain.Entities;
using Blog.Infraestructure.Presistance.Context;
using Blog.Infraestructure.Presistance.Core;

namespace Blog.Infraestructure.Presistance.Repository
{
	public class TagRepository : BaseSoftDeleteCompleteRepository<Tag>, ITagRepository
	{
		private readonly ApplicationContext _context;

		public TagRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<bool> UpdateAsync(Tag entity)
		{
			if (entity == null) return false;

			Tag tagToBeUpdated = await _context.Tags.FindAsync(entity.Id);

			tagToBeUpdated.Name = entity.Name;
			tagToBeUpdated.Description = entity.Description;
			tagToBeUpdated.LastUpdateDate = DateTime.UtcNow;
			tagToBeUpdated.LastUpdatedBy = entity.LastUpdatedBy; 

			return await base.UpdateAsync(tagToBeUpdated);
		}
	}
}
