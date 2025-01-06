
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Tags.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.Tags.Validator
{
    public class TagValidator : IModelValidator<SaveTagModel>
    {
        public Result IsModelValid(SaveTagModel model)
        {
            TagValidationsRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);
            return validationResult.IsValid ? 
                Result.Success() 
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }
    internal class TagValidationsRules : AbstractValidator<SaveTagModel>
    {
        public TagValidationsRules()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .WithMessage("The tag name cant be empty")
                .MaximumLength(100)
                .WithMessage("The tag name cant be longer than 100 characters")
                .MinimumLength(10)
                .WithMessage("The tag name cant be lesser than 10 characters");

            RuleFor(t => t.Description)
                .NotEmpty()
                .WithMessage("The tag description cant be empty")
                .MaximumLength(250)
                .WithMessage("The tag descption cant be longer than 250 characters")
                .MinimumLength(50)
                .WithMessage("The tag description cant be lesser than 50 characters");

        }
    }

}
