

using Blog.Core.Application.Core;
using Blog.Infraestructure.Identity.Core;
using Blog.Infraestructure.Presistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Infraestructure.Presistance.Core
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity>
		where TEntity : BaseEntity
	{
		private readonly ApplicationContext _context;
		private readonly DbSet<TEntity> _entities;

		public BaseRepository(ApplicationContext context)
		{
			_context = context;
			_entities = _context.Set<TEntity>();
		}
		public async Task<bool> ExitsAsync(Expression<Func<TEntity, bool>> filter)
		{
			return await _entities.AnyAsync(filter);
		}

		public async Task<bool> SaveAsync(TEntity entity)
		{
			try
			{
				await _entities.AddAsync(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public async Task<bool> DeleteAsync(int id)
		{

			try
			{
				TEntity entityToBeDeleted = await _entities.FindAsync(id);
				if (entityToBeDeleted == null) return false;

				_entities.Remove(entityToBeDeleted);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}


	}

	public class BaseCompleteRepository<TEntity> : BaseRepository<TEntity>, IBaseCompleteRepository<TEntity>
		where TEntity : BaseEntity
	{
		private readonly ApplicationContext _context;
		private readonly DbSet<TEntity> _entities;


		public BaseCompleteRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{	
			return await Task.FromResult( _entities.AsEnumerable());
		}

		public async Task<TEntity> GetByIdAsync(int id)
		{
			return await _entities.FindAsync(id);
		}

		public async Task<bool> UpdateAsync(TEntity entity)
		{
			try
			{
				_entities.Attach(entity);
				_entities.Entry(entity).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
