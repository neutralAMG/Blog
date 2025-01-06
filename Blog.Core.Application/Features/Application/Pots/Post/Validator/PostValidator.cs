

using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Pots.Pots.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.Pots.Post.Validator
{
    public class PostValidator : IModelValidator<SavePostModel>
    {
        public Result IsModelValid(SavePostModel model)
        {
            PostValidationsRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid 
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }

    internal class PostValidationsRules : AbstractValidator<SavePostModel>
    {
        public PostValidationsRules()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("The post title cant be empty")
                .MinimumLength(50)
                .WithMessage("The post title cant be lesser than 50 characters")
                .MaximumLength(200)
                .WithMessage("The post title cant be longer than 200 characters");

            RuleFor(p => p.PostContent)
                .NotEmpty()
                .WithMessage("The post content cant be empty");

            RuleFor(p => p.BlogId)
                .NotEmpty()
                .WithMessage("The blog id cant be empty")
                .GreaterThan(0)
                .WithMessage("The blog id provided was invalid");
        }
    }
}
