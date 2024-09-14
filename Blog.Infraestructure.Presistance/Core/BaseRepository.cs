

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
		public virtual async Task<bool> ExitsAsync(Expression<Func<TEntity, bool>> filter)
		{
			return await _entities.AnyAsync(filter);
		}

		public virtual async Task<bool> SaveAsync(TEntity entity)
		{
			try
			{
				entity.DateCreated = DateTime.UtcNow;
				await _entities.AddAsync(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public virtual async Task<bool> DeleteAsync(int id)
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
			_entities = _context.Set<TEntity>();
		}

		public virtual async Task<List<TEntity>> GetAllAsync()
		{	
			return await _entities.ToListAsync();
		}

		public virtual async Task<TEntity> GetByIdAsync(int id)
		{
			return await _entities.FindAsync(id);
		}

		public virtual IQueryable<TEntity> GetQueribleEntity()
		{
			return _entities;
		}

		public virtual async Task<bool> UpdateAsync(TEntity entity)
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

	public class BaseSoftDeleteCompleteRepository<TEntity> : BaseCompleteRepository<TEntity>
		where TEntity : BaseEntity, IBaseSoftDeleteEntity
	{
		private readonly ApplicationContext _context;
		private readonly DbSet<TEntity> _entities;

		public BaseSoftDeleteCompleteRepository(ApplicationContext context) : base(context)
		{
			_context = context;
			_entities = _context.Set<TEntity>();
		}
		public override async Task<bool> DeleteAsync(int id )
		{
			TEntity entityToBeDeleted = await _entities.FindAsync(id);

			if (entityToBeDeleted == null) return false;

			entityToBeDeleted.IsDeleted = true;

			entityToBeDeleted.DeleteTime = DateTime.UtcNow;

			_entities.Attach(entityToBeDeleted);

			_entities.Entry(entityToBeDeleted).State = EntityState.Modified;

		    await _context.SaveChangesAsync();

			return true;

		}
	}
}
