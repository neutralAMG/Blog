
using Blog.Core.Application.Core;
using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Application.Pots.PostTags.Models;
using Blog.Core.Domain.Enums;
using FluentValidation;

namespace Blog.Core.Application.Features.Application.Pots.PostTags.Validator
{
    public class PostTagValidator : IModelValidator<SavePostTagModel>
    {
        public Result IsModelValid(SavePostTagModel model)
        {
            PostTagValidatonRules validationRules = new();

            FluentValidation.Results.ValidationResult validationResult = validationRules.Validate(model);

            return validationResult.IsValid 
                ? Result.Success()
                : ErrorTypess.ValidationMissMatch.Because(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }

    internal class PostTagValidatonRules : AbstractValidator<SavePostTagModel>
    {
        public PostTagValidatonRules()
        {
            RuleFor(pt => pt.PostId)
                .NotEmpty()
                .WithMessage("The post id cant be empty")
                .GreaterThan(0)
                .WithMessage("The post id was invalid");

            RuleFor(pt => pt.TagId)
               .NotEmpty()
               .WithMessage("The tag id cant be empty")
               .GreaterThan(0)
               .WithMessage("The tag id was invalid");
        }
    }
}
