using Blog.Core.Application.Core;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Application.Features.Application.Blogs.BlogCategories.Interfaces
{
    public interface IBlogCategoryRepository : IBaseRepository<BlogCategory> , IDeleteEntityMToMRelationshipEntity
    {

    }
}
