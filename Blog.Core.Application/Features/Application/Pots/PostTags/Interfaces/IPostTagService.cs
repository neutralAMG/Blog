
using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Pots.PostTags.Models;

namespace Blog.Core.Application.Features.Application.Pots.PostTags.Interfaces
{
    public interface IPostTagService : IBaseService<SavePostTagModel>
    {
        Task<Result> AddOrUnAddTagToPostAsync(int postId, int tagId);
    }
}
