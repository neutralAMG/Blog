

using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Categories.Models;


namespace Blog.Core.Application.Features.Application.Categories.Interfaces
{
    public interface ICategoryService : IBaseCompleteService<SaveCategoryModel, CategoryModel> 
    {
    }
}
