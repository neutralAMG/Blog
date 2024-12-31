using AutoMapper;
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Categories.Interfaces;
using Blog.Core.Application.Features.Application.Categories.Models;
using Blog.Core.Application.Features.Application.Categories.Validations;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.Enums;

namespace Blog.Core.Application.Features.Application.Categories
{
    public class CategoryService : BaseCompleteService<SaveCategoryModel, CategoryModel, Category>, ICategoryService
    {
        private readonly CategoryValidations _validationRules;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryValidations validationRules) : base(categoryRepository, mapper)
        {
            _validationRules = validationRules;
        }

        public async override Task<Result> SaveAsync(SaveCategoryModel saveModel)
        {
            var validation = _validationRules.Validate(saveModel);

            if (!validation.IsValid)
                return ErrorTypess.ValidationMissMatch.Because(validation.Errors.First().ErrorMessage);

            return await base.SaveAsync(saveModel);
        }
    }
}
