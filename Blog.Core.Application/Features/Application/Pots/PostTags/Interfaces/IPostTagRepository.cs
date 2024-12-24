using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;


namespace Blog.Core.Application.Features.Application.Pots.PostTags.Interfaces
{
    public interface IPostTagRepository : IBaseRepository<PostTag>, IDeleteEntityMToMRelationshipEntity
    {
    }
}
