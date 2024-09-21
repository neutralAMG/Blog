
namespace Blog.Core.Application.Core
{
	public interface IBaseService<TSaveModel>
		where TSaveModel : class
	{
		Task<Result> SaveAsync(TSaveModel entity);
		Task<Result> DeleteAsync(int id);
	}
	public interface IBaseCompleteService<TSaveModel, TModel> : IBaseService<TSaveModel>
		where TModel : class
		where TSaveModel: class
	{
		Task<Result<List<TModel>>> GetAllAsync();
		Task<Result<TModel>> GetByIdAsync(int id);
		Task<Result> UpdateAsync(TSaveModel entity);
	}
}
