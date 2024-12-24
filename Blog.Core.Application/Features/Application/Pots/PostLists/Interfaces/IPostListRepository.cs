using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Features.Application.Pots.PostLists.Interfaces
{
    public interface IPostListRepository : IBaseRepository<PostList> , IDeleteEntityMToMRelationshipEntity
    {
    }
}
