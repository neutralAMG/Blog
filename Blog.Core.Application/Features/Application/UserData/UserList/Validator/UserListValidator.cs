using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.UserData.UserList.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.UserData.UserList.Validator
{
    public class UserListValidator : IModelValidator<SaveUserListModel>
    {
        public Result IsModelValid(SaveUserListModel model)
        {
            UserListValidationsRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }

    internal class UserListValidationsRules : AbstractValidator<SaveUserListModel>
    {
        public UserListValidationsRules()
        {
            RuleFor(b => b.Name)
                .NotEmpty()
                .WithMessage("The name cant be empty")
                .MinimumLength(10)
                .WithMessage("The name cant be lesser than 10 charactares")
                .MaximumLength(100)
                .WithMessage("The name cant be greater than 100 characters");

            RuleFor(b => b.Description)
                .NotEmpty()
                .WithMessage("The description cant be empty")
                .MinimumLength(50)
                .WithMessage("The description cant be lesser than 50")
                .MaximumLength(250)
                .WithMessage("The description cant be longer than 250");

            RuleFor(b => b.UserId)
                .Empty()
                .WithMessage("The user id cant be empty");
        }
    }

}
