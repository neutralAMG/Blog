

using Blog.Core.Application.Core;
using Blog.Core.Application.Features.Application.Pots.PostLists.Models;

namespace Blog.Core.Application.Features.Application.Pots.PostLists.Interfaces
{
    public interface IPostListService : IBaseService<SavePostListModel>
    {
        Task<Result> AddOrUnAddPostToListAsync(int postId, int listId);
    }
}
