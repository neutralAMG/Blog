using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Categories.Interfaces;
using Blog.Core.Application.Features.Application.Categories.Models;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Categories
{
    public class CategoryService : BaseCompleteService<SaveCategoryModel, CategoryModel, Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : base(categoryRepository, mapper)
        {
        }
    }
}
