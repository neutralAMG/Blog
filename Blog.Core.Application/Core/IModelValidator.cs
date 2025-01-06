
namespace Blog.Core.Application.Core
{
    public interface IModelValidator<TModel> where TModel : class
    {
        Result IsModelValid(TModel model);
    }
}
