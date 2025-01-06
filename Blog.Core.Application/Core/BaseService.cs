
using AutoMapper;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Utls;
using Blog.Core.Domain.Enums;
using Blog.Infraestructure.Identity.Core;

namespace Blog.Core.Application.Core
{
    public class BaseService<TSaveModel, TEntity> : IBaseService<TSaveModel>
        where TSaveModel : class
        where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IModelValidator<TSaveModel> _validator;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper, IModelValidator<TSaveModel> validator)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public virtual async Task<Result> SaveAsync(TSaveModel saveModel)
        {
            Result ValidationResult = _validator.IsModelValid(saveModel);

            if (!ValidationResult.IsSuccess)
                return ValidationResult;

            Result<TEntity> mapResult = _mapper.MapSafely<TEntity>(saveModel);

            if (!mapResult.IsSuccess)
                return ErrorTypess.OperationFaild.Because(mapResult.Message);

            TEntity entityToBeSaved = mapResult.Data;

            bool isOperationASuccess = await _baseRepository.SaveAsync(entityToBeSaved);

            return !isOperationASuccess 
                ?  ErrorTypess.OperationFaild.Because("Error while trying to save the entity") 
                : Result.Success(ResultMessages.DefaultMessages.Add_Success);

        }
        public virtual async Task<Result> DeleteAsync(int id)
        {
            if (id <= 0)
                return ErrorTypess.ValidationMissMatch.Because("Id was ether empty or was invalid");

            bool IsOperationASuccess = await _baseRepository.DeleteAsync(id);

            return !IsOperationASuccess 
                ? ErrorTypess.OperationFaild.Because("Error while deleteng the entity") 
                : Result.Success("Entity was deleted successfully");
        }


    }

    public class BaseCompleteService<TSaveModel, TModel, TEntity> : BaseService<TSaveModel, TEntity>, IBaseCompleteService<TSaveModel, TModel>
        where TSaveModel : class
        where TModel : class
        where TEntity : BaseEntity
    {
        private readonly IBaseCompleteRepository<TEntity> _baseCompleteRepository;
        private readonly IMapper _mapper;
        private readonly IModelValidator<TSaveModel> _validator;

        public BaseCompleteService(IBaseCompleteRepository<TEntity> baseCompleteRepository, IMapper mapper, IModelValidator<TSaveModel> validator) : base(baseCompleteRepository, mapper, validator)
        {
            _baseCompleteRepository = baseCompleteRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public virtual async Task<Result<List<TModel>>> GetAllAsync()
        {
            List<TEntity> entitiesGetted = await _baseCompleteRepository.GetAllAsync();

            if (entitiesGetted == null)
                return ErrorTypess.OperationFaild.Because("The entities list was not found");

            return _mapper.MapSafely<List<TModel>>(entitiesGetted);
        }

        public virtual async Task<Result<TModel>> GetByIdAsync(int id)
        {
            if (id <= 0)
                return ErrorTypess.ValidationMissMatch.Because("The id was ether null or invalid");

            TEntity entityGetted = await _baseCompleteRepository.GetByIdAsync(id);

            if (entityGetted == null)
                return ErrorTypess.ValidationMissMatch.Because("The entity was not found");

            return _mapper.MapSafely<TModel>(entityGetted);
        }

        public virtual async Task<Result> UpdateAsync(TSaveModel entity)
        {
            Result validatorResult = _validator.IsModelValid(entity);

            if (!validatorResult.IsSuccess)
                return validatorResult;

            Result<TEntity> mapResult = _mapper.MapSafely<TEntity>(entity);

            if (!mapResult.IsSuccess)
                return ErrorTypess.OperationFaild.Because(mapResult.Message);

            TEntity entityToBeUpdated = mapResult.Data;

            bool IsUpdateOperationASuccess = await _baseCompleteRepository.UpdateAsync(entityToBeUpdated);

            return !IsUpdateOperationASuccess 
                ? ErrorTypess.OperationFaild.Because("Error while trying to update the entity") 
                : Result.Success("The entity was updated successfully");
        }
    }
}
