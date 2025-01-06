using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Categories.Interfaces;
using Blog.Core.Application.Features.Application.Categories.Models;
using Blog.Core.Application.Features.Application.Categories.Validations;
using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Features.Application.Categories
{
    public class CategoryService : BaseCompleteService<SaveCategoryModel, CategoryModel, Category>, ICategoryService
    {
        private readonly CategoryValidatior _validationRules;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryValidatior validationRules, CategoryValidatior categoryValidatior) : base(categoryRepository, mapper, categoryValidatior)
        {
            _validationRules = validationRules;
        }
    }
}
