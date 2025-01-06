using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;


namespace Blog.Core.Application.Features.Application.Blogs.BlogFavorites.Validator
{
    public class BlogFavoriteValidator : IModelValidator<SaveBlogFavoriteModel>
    {
        public Result IsModelValid(SaveBlogFavoriteModel model)
        {
            BlogFavoriteValidatonRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }

    internal class BlogFavoriteValidatonRules : AbstractValidator<SaveBlogFavoriteModel>
    {
        public BlogFavoriteValidatonRules()
        {
            RuleFor(bf => bf.BlogId)
                .NotEmpty()
                .WithMessage("The blog id cant be empty")
                .GreaterThan(0)
                .WithMessage("The blog id was invalid");

            RuleFor(bf => bf.UserId)
               .NotEmpty()
               .WithMessage("The user id cant be empty");
        }
    }
}
