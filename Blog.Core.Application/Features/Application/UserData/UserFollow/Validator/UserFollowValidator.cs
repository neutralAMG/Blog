
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.UserData.UserFollow.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.UserData.UserFollow.Validator
{
    public class UserFollowValidator : IModelValidator<SaveUserFollowModel>
    {
        public Result IsModelValid(SaveUserFollowModel model)
        {
            UserFollowValidationRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }

    internal class UserFollowValidationRules : AbstractValidator<SaveUserFollowModel>
    {
        public UserFollowValidationRules()
        {
            RuleFor(uf => uf.FolloweId)
                .NotEmpty()
                .WithMessage("The followe id cant be empty");

            RuleFor(uf => uf.FollowerId)
            .NotEmpty()
            .WithMessage("The follower id cant be empty");
        }
    }
}
