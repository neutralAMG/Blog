
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Comments.CommentLikes.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.Comments.CommentLikes.Validator
{
    public class CommentLikeValidator : IModelValidator<SaveCommentLikeModel>
    {
        public Result IsModelValid(SaveCommentLikeModel model)
        {
            CommentLikeValidatonRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        internal class CommentLikeValidatonRules : AbstractValidator<SaveCommentLikeModel>
        {
            public CommentLikeValidatonRules()
            {
                RuleFor(cl => cl.CommentId)
                    .NotEmpty()
                    .WithMessage("The comment id cant be empty")
                    .GreaterThan(0)
                    .WithMessage("The comment id was invalid");

                RuleFor(cl => cl.UserId)
                   .NotEmpty()
                   .WithMessage("The user id cant be empty");
            }
        }

    }
}
