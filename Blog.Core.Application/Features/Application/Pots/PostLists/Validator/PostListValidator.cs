using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Pots.PostLists.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.Pots.PostLists.Validator
{
    public class PostListValidator : IModelValidator<SavePostListModel>
    {
        public Result IsModelValid(SavePostListModel model)
        {
            PostListValidatonRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid 
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }
    internal class PostListValidatonRules : AbstractValidator<SavePostListModel>
    {
        public PostListValidatonRules()
        {
            RuleFor(pl => pl.PostId)
                .NotEmpty()
                .WithMessage("The post id cant be empty")
                .GreaterThan(0)
                .WithMessage("The post id was invalid");

            RuleFor(pl => pl.UserListId)
               .NotEmpty()
               .WithMessage("The user id cant be empty")
               .GreaterThan(0)
               .WithMessage("The list id was invalid");
        }
    }

}
