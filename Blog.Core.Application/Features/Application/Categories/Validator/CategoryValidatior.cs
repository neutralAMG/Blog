using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Categories.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;


namespace Blog.Core.Application.Features.Application.Categories.Validations
{
    public class CategoryValidatior : IModelValidator<SaveCategoryModel>
    {
        public Result IsModelValid(SaveCategoryModel model)
        {
            CategoryValidationsRules validationRules = new();

            FluentValidation.Results.ValidationResult validation = validationRules.Validate(model);

            return validation.IsValid ?
                Result.Success() :
                ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validation.Errors.Select(e => e.ErrorMessage)));
        }
    }

    internal class CategoryValidationsRules : AbstractValidator<SaveCategoryModel>
    {
        public CategoryValidationsRules()
        {
            RuleFor(category => category.Name)
              .NotEmpty()
              .WithMessage("the category name cant be empty")
              .MaximumLength(100)
              .WithMessage("the category name cant be longer than 100 characters")
              .MinimumLength(10)
              .WithMessage("the category name cant be lesser than 10 characters");

            RuleFor(category => category.Description)
              .NotEmpty()
              .WithMessage("the category description cant be empty")
              .MaximumLength(250)
              .WithMessage("the category description cant be longer than 250 characters")
              .MinimumLength(50)
              .WithMessage("the category description cant be lesser than 50 characters");
        }
    }
}
