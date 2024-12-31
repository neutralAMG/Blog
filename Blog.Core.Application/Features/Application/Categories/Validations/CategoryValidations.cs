using Blog.Core.Application.Features.Application.Categories.Models;
using FluentValidation;


namespace Blog.Core.Application.Features.Application.Categories.Validations
{
    public class CategoryValidations : AbstractValidator<SaveCategoryModel>
    {
        public CategoryValidations()
        {
            RuleFor(category => category.Name)
                   .NotEmpty()
                   .WithMessage("the category name cant be empty");

            RuleFor(category => category.Name)
              .MaximumLength(100)
              .WithMessage("the category name cant be longer than 100 characters");

            RuleFor(category => category.Name)
              .MinimumLength(10)
              .WithMessage("the category name cant be lesser than 10 characters");

            RuleFor(category => category.Description)
              .NotEmpty()
              .WithMessage("the category description cant be longer than 100 characters");

            RuleFor(category => category.Description)
              .MaximumLength(250)
              .WithMessage("the category description cant be longer than 100 characters");

            RuleFor(category => category.Description)
              .MaximumLength(50)
              .WithMessage("the category description cant be longer than 100 characters");
        }
    }
}
