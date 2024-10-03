using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Pots.Pots.Models;


namespace Blog.Core.Application.Features.Application.Pots.Pots.Interfaces
{
    public interface IPostService : IBaseCompleteService<SavePostModel, PostModel>
    {
        Task<Result<List<PostModel>>> GetByTagIdAsync(int tagId);
    }
}
