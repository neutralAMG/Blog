

using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Comments.Comments.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.Comments.Comments.Validator
{
    public class CommentValidator : IModelValidator<SaveCommentModel>
    {
        public Result IsModelValid(SaveCommentModel model)
        {
            CommentValidationRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }

    internal class CommentValidationRules : AbstractValidator<SaveCommentModel>
    {
        public CommentValidationRules()
        {
            RuleFor(c => c.TextContent)
                .NotEmpty()
                .WithMessage("The comment cant be empty")
                .MaximumLength(500)
                .WithMessage("The comment cant be longer than 500 characters");

            RuleFor(c => c.PostId)
                .NotEmpty()
                .WithMessage("The post id is empty")
                .GreaterThan(0)
                .WithMessage("The id provider was invalid");

            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("The user id cant be empty");
        }
    }

}
