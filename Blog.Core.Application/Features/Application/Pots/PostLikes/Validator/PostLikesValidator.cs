using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Pots.PostLikes.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.Pots.PostLikes.Validator
{
    public class PostLikesValidator : IModelValidator<SavePostLikeModel>
    {
        public Result IsModelValid(SavePostLikeModel model)
        {
            PostLikesValidatonRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid 
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }

    internal class PostLikesValidatonRules : AbstractValidator<SavePostLikeModel>
    {
        public PostLikesValidatonRules()
        {
            RuleFor(pl => pl.PostId)
                .NotEmpty()
                .WithMessage("The post id cant be empty")
                .GreaterThan(0)
                .WithMessage("The post id was invalid");

            RuleFor(pl => pl.UserId)
               .NotEmpty()
               .WithMessage("The user id cant be empty");
        }
    }
}
