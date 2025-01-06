using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Blogs.BlogCategories.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;


namespace Blog.Core.Application.Features.Application.Blogs.BlogCategories.Validator
{
    public class BlogCategoryValidator : IModelValidator<SaveBlogCategoryModel>
    {
        public Result IsModelValid(SaveBlogCategoryModel model)
        {
            BlogCategoryValidatonRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }

    internal class BlogCategoryValidatonRules : AbstractValidator<SaveBlogCategoryModel>
    {
        public BlogCategoryValidatonRules()
        {
            RuleFor(bc => bc.BlogId)
                .NotEmpty()
                .WithMessage("The blog id cant be empty")
                .GreaterThan(0)
                .WithMessage("The blog id was invalid");

            RuleFor(bc => bc.CategoryId)
               .NotEmpty()
               .WithMessage("The category id cant be empty")
               .GreaterThan(0)
               .WithMessage("The category id was invalid");
        }
    }
}
