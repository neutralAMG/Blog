
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Blogs.Blogs.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.Blogs.Blogs.Validator
{
    public class BlogValidator : IModelValidator<SaveBlogModel>
    {
        public Result IsModelValid(SaveBlogModel model)
        {
            BlogValidatonsRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }
    internal class BlogValidatonsRules : AbstractValidator<SaveBlogModel>
    {
        public BlogValidatonsRules()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage("The title cant be empty")
                .MinimumLength(10)
                .WithMessage("The title cant be lesser than 10 charactares")
                .MaximumLength(100)
                .WithMessage("The title cant be greater than 100 characters");

            RuleFor(b => b.Summary)
                .NotEmpty()
                .WithMessage("The summary cant be empty")
                .MinimumLength(50)
                .WithMessage("The summary cant be lesser than 50")
                .MaximumLength(250)
                .WithMessage("The summary cant be longer than 250");

            RuleFor(b => b.UserId)
                .Empty()
                .WithMessage("The user id cant be empty");
        }
    }
}
