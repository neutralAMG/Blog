

using Blog.Infraestructure.Identity.Core;
using System.Linq.Expressions;

namespace Blog.Core.Application.Core
{
	public interface IBaseRepository<TEntity>
		where TEntity : BaseEntity
	{
		Task<bool> ExitsAsync(Expression<Func<TEntity, bool>> filter);
		Task<bool> SaveAsync(TEntity entity);
		Task<bool> DeleteAsync(int id);
	}

	public interface IBaseCompleteRepository<TEntity> : IBaseRepository<TEntity>
		where TEntity : BaseEntity
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(int id);
		Task<bool> UpdateAsync(TEntity entity);
	}
}
