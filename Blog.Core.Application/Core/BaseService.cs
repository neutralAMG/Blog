

using AutoMapper;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Utls.Enums;
using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Application.Core
{
	public class BaseService<TSaveModel, TEntity> : IBaseService<TSaveModel>
		where TSaveModel : class
		where TEntity : BaseEntity
	{
		private readonly IBaseRepository<TEntity> _baseRepository;
		private readonly IMapper _mapper;

		public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
			_baseRepository = baseRepository;
			_mapper = mapper;
		}		
		public async Task<Result> SaveAsync(TSaveModel saveModel)
		{
			try
			{
				if (saveModel == null)
					return ErrorTypess.ValidationMissMatch.Because("The entity to be save cant be null");

				TEntity entityToBeSaved = _mapper.Map<TEntity>(saveModel);

				bool isOperationASuccess = await _baseRepository.SaveAsync(entityToBeSaved);

				return !isOperationASuccess ? ErrorTypess.OperationFaild.Because("Error while trying to save the entity") :
					Result.Success("The entity was saved successfully");
			}
			catch
			{
				return ErrorTypess.Exeption.Because("Critical error while saving the entity to the database");
			}
		}
        public async Task<Result> DeleteAsync(int id)
		{
			try
			{
				if (id <= 0)
					return ErrorTypess.ValidationMissMatch.Because("Id was ether empty or was invalid");

				bool IsOperationASuccess = await _baseRepository.DeleteAsync(id);

				return !IsOperationASuccess ? ErrorTypess.OperationFaild.Because("Error while deleteng the entity") :
					Result.Success("Entity was deleted successfully");
			}
			catch
			{
				return ErrorTypess.Exeption.Because("Critical error while trying to delete the entity");
			}
		}


	}
}
